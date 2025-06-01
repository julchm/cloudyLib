using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using cloudyLib.Data;
using cloudyLib.Models;

namespace cloudyLib.Forms
{
    public partial class AddEditLoanForm : Form
    {
        private readonly LibraryDbContext _db;
        private int? _bookLoanIdToEdit; 
        private BookLoan? _loanBeingEdited; 

      
        public AddEditLoanForm(LibraryDbContext db)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            ConfigureFormControls();
            this.Load += async (s, e) => await LoadFormData();
        }

        public void SetLoanToEdit(int? bookLoanId)
        {
            _bookLoanIdToEdit = bookLoanId;
        }

        private void ConfigureFormControls()
        {
            this.Text = "Dodaj/Edytuj Wypożyczenie";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.AntiqueWhite;

            if (cmbBook != null)
            {
                cmbBook.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbBook.DisplayMember = "Title"; 
                cmbBook.ValueMember = "BookId";  
                LoadBooksIntoComboBox();
            }

            if (cmbUser != null)
            {
                cmbUser.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbUser.DisplayMember = "FullName"; 
                cmbUser.ValueMember = "UserId";     
                LoadUsersIntoComboBox();
            }

            if (dtpLoanDate != null) dtpLoanDate.Value = DateTime.Today;
            if (dtpPlannedReturnDate != null) dtpPlannedReturnDate.Value = DateTime.Today.AddDays(14); 

            if (chkReturned != null)
            {
                chkReturned.CheckedChanged += ChkReturned_CheckedChanged;
                lblReturnDate.Visible = false;
                dtpReturnDate.Visible = false;
                dtpReturnDate.Value = DateTime.Today;
            }


            if (btnSave != null) btnSave.Click += BtnSave_Click;
            if (btnCancel != null) btnCancel.Click += (s, e) => this.Close();

            if (lblMessage != null)
            {
                lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                lblMessage.Visible = false;
            }
        }

        private async Task LoadBooksIntoComboBox()
        {
            try
            {
                var books = await _db.Books
                                     .OrderBy(b => b.Title)
                                     .Select(b => new { b.BookId, b.Title, b.AvailableCopies })
                                     .ToListAsync();
                if (cmbBook != null)
                {
                    cmbBook.DataSource = books;
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd ładowania książek: {ex.Message}", true);
            }
        }

        private async Task LoadUsersIntoComboBox()
        {
            try
            {
                var users = await _db.Users
                                     .OrderBy(u => u.LastName)
                                     .Select(u => new { u.UserId, FullName = $"{u.FirstName} {u.LastName} ({u.Email})" })
                                     .ToListAsync();
                if (cmbUser != null)
                {
                    cmbUser.DataSource = users;
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd ładowania użytkowników: {ex.Message}", true);
            }
        }

        private void ChkReturned_CheckedChanged(object sender, EventArgs e)
        {
            if (lblReturnDate != null) lblReturnDate.Visible = chkReturned.Checked;
            if (dtpReturnDate != null) dtpReturnDate.Visible = chkReturned.Checked;
        }

        private async Task LoadFormData()
        {
            if (_bookLoanIdToEdit.HasValue)
            {
                lblTitle.Text = "Edytuj Wypożyczenie";
                try
                {
                    _loanBeingEdited = await _db.BookLoans
                                                .Include(bl => bl.Book) 
                                                .Include(bl => bl.User) 
                                                .FirstOrDefaultAsync(bl => bl.BookLoanId == _bookLoanIdToEdit.Value);

                    if (_loanBeingEdited != null)
                    {
                        if (cmbBook != null) cmbBook.SelectedValue = _loanBeingEdited.BookId;
                        if (cmbUser != null) cmbUser.SelectedValue = _loanBeingEdited.UserId;
                        if (dtpLoanDate != null) dtpLoanDate.Value = _loanBeingEdited.LoanDate;
                        if (dtpPlannedReturnDate != null) dtpPlannedReturnDate.Value = _loanBeingEdited.PlannedReturnDate ?? DateTime.Today.AddDays(14);

                        if (_loanBeingEdited.ReturnDate.HasValue)
                        {
                            if (chkReturned != null) chkReturned.Checked = true;
                            if (dtpReturnDate != null) dtpReturnDate.Value = _loanBeingEdited.ReturnDate.Value;
                            SetPasswordFieldsVisibility(true); 
                        }
                        else
                        {
                            if (chkReturned != null) chkReturned.Checked = false;
                            SetPasswordFieldsVisibility(false); 
                        }

                        if (cmbBook != null) cmbBook.Enabled = false; 
                        if (cmbUser != null) cmbUser.Enabled = false; 
                        if (dtpLoanDate != null) dtpLoanDate.Enabled = false; 
                    }
                    else
                    {
                        ShowMessage("Nie znaleziono wypożyczenia do edycji.", true);
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage($"Błąd podczas ładowania danych wypożyczenia: {ex.Message}", true);
                }
            }
            else
            {
                lblTitle.Text = "Dodaj Nowe Wypożyczenie";
                if (cmbBook != null) cmbBook.Enabled = true;
                if (cmbUser != null) cmbUser.Enabled = true;
                if (dtpLoanDate != null) dtpLoanDate.Enabled = true;
                if (chkReturned != null) chkReturned.Checked = false; 
                SetPasswordFieldsVisibility(false); 
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            ShowMessage("Zapisywanie...", false);

            if (!ValidateForm())
            {
                return;
            }

            try
            {
                int selectedBookId = (int)cmbBook.SelectedValue;
                int selectedUserId = (int)cmbUser.SelectedValue;

                if (_bookLoanIdToEdit.HasValue) 
                {
                    if (_loanBeingEdited != null)
                    {
                        int oldBookId = _loanBeingEdited.BookId;
                        bool wasActive = (_loanBeingEdited.ReturnDate == null);

                        _loanBeingEdited.PlannedReturnDate = dtpPlannedReturnDate.Value;

                        if (chkReturned.Checked)
                        {
                            _loanBeingEdited.ReturnDate = dtpReturnDate.Value;
                        }
                        else
                        {
                            _loanBeingEdited.ReturnDate = null; 
                        }

                        if (wasActive && _loanBeingEdited.ReturnDate.HasValue) 
                        {
                            var book = await _db.Books.FindAsync(oldBookId);
                            if (book != null)
                            {
                                book.AvailableCopies++;
                                _db.Books.Update(book);
                            }
                        }
                        else if (!wasActive && _loanBeingEdited.ReturnDate == null) 
                        {
                            var book = await _db.Books.FindAsync(oldBookId);
                            if (book != null)
                            {
                                book.AvailableCopies--;
                                _db.Books.Update(book);
                            }
                        }

                        _db.BookLoans.Update(_loanBeingEdited);
                        await _db.SaveChangesAsync();
                        MessageBox.Show("Dane wypożyczenia zostały zaktualizowane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else 
                {
                    var bookToLoan = await _db.Books.FindAsync(selectedBookId);
                    if (bookToLoan == null || bookToLoan.AvailableCopies <= 0)
                    {
                        ShowMessage("Wybrana książka nie jest dostępna do wypożyczenia.", true);
                        return;
                    }

                    var existingActiveLoan = await _db.BookLoans
                                                        .AnyAsync(bl => bl.BookId == selectedBookId &&
                                                                        bl.UserId == selectedUserId &&
                                                                        bl.ReturnDate == null);
                    if (existingActiveLoan)
                    {
                        ShowMessage("Ten użytkownik ma już aktywnie wypożyczoną tę książkę.", true);
                        return;
                    }

                    var newLoan = new BookLoan
                    {
                        BookId = selectedBookId,
                        UserId = selectedUserId,
                        LoanDate = dtpLoanDate.Value,
                        PlannedReturnDate = dtpPlannedReturnDate.Value,
                        ReturnDate = chkReturned.Checked ? dtpReturnDate.Value : (DateTime?)null 
                    };

                    bookToLoan.AvailableCopies--;
                    _db.Books.Update(bookToLoan);

                    _db.BookLoans.Add(newLoan);
                    await _db.SaveChangesAsync();
                    MessageBox.Show("Nowe wypożyczenie zostało dodane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas zapisu: {ex.Message}", true);
            }
        }

        private bool ValidateForm()
        {
            if (cmbBook == null || cmbBook.SelectedValue == null)
            {
                ShowMessage("Proszę wybrać książkę.", true);
                return false;
            }
            if (cmbUser == null || cmbUser.SelectedValue == null)
            {
                ShowMessage("Proszę wybrać użytkownika.", true);
                return false;
            }
            if (dtpLoanDate == null || dtpPlannedReturnDate == null)
            {
                ShowMessage("Błąd wewnętrzny formularza dat.", true);
                return false;
            }

            if (dtpPlannedReturnDate.Value < dtpLoanDate.Value)
            {
                ShowMessage("Planowana data zwrotu nie może być wcześniejsza niż data wypożyczenia.", true);
                return false;
            }

            if (chkReturned.Checked)
            {
                if (dtpReturnDate == null)
                {
                    ShowMessage("Błąd wewnętrzny formularza daty zwrotu.", true);
                    return false;
                }
                if (dtpReturnDate.Value < dtpLoanDate.Value)
                {
                    ShowMessage("Data zwrotu nie może być wcześniejsza niż data wypożyczenia.", true);
                    return false;
                }
                if (dtpReturnDate.Value > DateTime.Today)
                {
                    ShowMessage("Data zwrotu nie może być w przyszłości.", true);
                    return false;
                }
            }
            return true;
        }

        private void SetPasswordFieldsVisibility(bool visible) 
        {
            if (lblReturnDate != null) lblReturnDate.Visible = visible;
            if (dtpReturnDate != null) dtpReturnDate.Visible = visible;
        }

        private void ShowMessage(string message, bool isError)
        {
            if (lblMessage != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(() => ShowMessage(message, isError)));
                    return;
                }
                lblMessage.Text = message;
                lblMessage.ForeColor = isError ? Color.Red : Color.DarkGreen;
                lblMessage.Visible = !string.IsNullOrEmpty(message);
            }
        }
    }
}