using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCCAMD.Pages
{
    public partial class Courts : Page
    {
        private String[] headers = new String[] { "", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        private int startHour = 8;
        private int endHour = 21;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            initBookingsTable();
        }

        protected void initBookingsTable()
        {
            int nbrColumns = headers.Length;

            //
            // Header row construction
            //
            TableHeaderRow headerRow = new TableHeaderRow();
            for (int headerNo = 0; headerNo < nbrColumns; headerNo++)
            {
                TableHeaderCell cell = new TableHeaderCell();
                cell.Text = headers[headerNo];

                headerRow.Cells.Add(cell);
            }
            tblBookings.Rows.Add(headerRow);

            //
            // Table content construction
            //
            for (int hour = startHour; hour <= endHour; hour++)
            {
                TableRow row = new TableRow();
                for (int columnNo = 0; columnNo < nbrColumns; columnNo++)
                {
                    TableCell cell = new TableCell();
                    cell.Wrap = false;
                    cell.VerticalAlign = VerticalAlign.Middle;

                    if (columnNo == 0)
                    {
                        cell.Text = String.Format("{0:D2}:00", hour);
                    }
                    else
                    {
                        TextBox txtUsername = new TextBox();
                        txtUsername.Width = Unit.Pixel(70);
                        txtUsername.Height = Unit.Pixel(15);

                        ImageButton btnSave = new ImageButton();
                        btnSave.ImageUrl = "../Images/save.png";
                        btnSave.Height = Unit.Pixel(15);
                        btnSave.Width = Unit.Pixel(15);
                        btnSave.Click += new ImageClickEventHandler(this.saveClick);
                        btnSave.ImageAlign = ImageAlign.AbsBottom;

                        cell.Controls.Add(txtUsername);
                        cell.Controls.Add(btnSave);
                    }

                    row.Cells.Add(cell);
                }
                tblBookings.Rows.Add(row);
            }

            System.Diagnostics.Debug.WriteLine("init");
        }

        public void addPlayer(TableCell cell, String username)
        {
            Label lblUsername = new Label();
            lblUsername.Text = username;

            ImageButton btnDelete = new ImageButton();
            btnDelete.ImageUrl = "../Images/delete.png";
            btnDelete.Height = Unit.Pixel(15);
            btnDelete.Width = Unit.Pixel(15);
            btnDelete.Click += new ImageClickEventHandler(this.deleteClick);
            btnDelete.ImageAlign = ImageAlign.AbsMiddle;
            //btnDelete.CausesValidation = false;
            //Page.RegisterRequiresRaiseEvent(btnDelete);

            cell.Controls.Clear();
            cell.Controls.Add(lblUsername);
            cell.Controls.Add(btnDelete);

            System.Diagnostics.Debug.WriteLine("added");
        }


        protected void saveClick(object sender, ImageClickEventArgs e)
        {
            ImageButton btnClicked = (ImageButton) sender;
            TableCell cell = (TableCell) btnClicked.Parent;
            TextBox username = (TextBox) cell.Controls[0];

            addPlayer(cell, username.Text);
            username.Text = "";
        }

        protected void deleteClick(object sender, ImageClickEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("deleted");
        }
    }
}