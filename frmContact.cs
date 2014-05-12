using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Business;

namespace Gnosis
{
	/// <summary>Maintenance Form for Contacts.</summary>
	public class frmContact : System.Windows.Forms.Form
	{
		private CContact m_oContacts;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Label lblLastname;
		private System.Windows.Forms.Label lblFirstname;
		private System.Windows.Forms.Label lblEmail;
		private System.Windows.Forms.Label lblPhone;
		private System.Windows.Forms.Label lblCreationDate;
		private System.Windows.Forms.Label lblLastModifiedDate;
		private System.Windows.Forms.TextBox txtLastname;
		private System.Windows.Forms.TextBox txtFirstname;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.TextBox txtCreationDate;
		private System.Windows.Forms.TextBox txtLastModifiedDate;
		private System.Windows.Forms.Label lblContactID;
		private System.Windows.Forms.TextBox txtContactID;
		private System.Windows.Forms.ToolBarButton tbbSave;
		private System.Windows.Forms.ToolBarButton tbbAdd;
		/// <summary>Required designer variable.</summary>
		private System.ComponentModel.Container components = null;

		public frmContact(string pConnectionString)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.m_oContacts = new CContact(pConnectionString);

			InitializeData(-1);
		}

		/// <summary>Clean up any resources being used.</summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblLastname = new System.Windows.Forms.Label();
			this.lblFirstname = new System.Windows.Forms.Label();
			this.lblEmail = new System.Windows.Forms.Label();
			this.lblPhone = new System.Windows.Forms.Label();
			this.lblCreationDate = new System.Windows.Forms.Label();
			this.lblLastModifiedDate = new System.Windows.Forms.Label();
			this.txtLastname = new System.Windows.Forms.TextBox();
			this.txtFirstname = new System.Windows.Forms.TextBox();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.txtCreationDate = new System.Windows.Forms.TextBox();
			this.txtLastModifiedDate = new System.Windows.Forms.TextBox();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbSave = new System.Windows.Forms.ToolBarButton();
			this.lblContactID = new System.Windows.Forms.Label();
			this.txtContactID = new System.Windows.Forms.TextBox();
			this.tbbAdd = new System.Windows.Forms.ToolBarButton();
			this.SuspendLayout();
			// 
			// lblLastname
			// 
			this.lblLastname.Location = new System.Drawing.Point(8, 68);
			this.lblLastname.Name = "lblLastname";
			this.lblLastname.Size = new System.Drawing.Size(100, 16);
			this.lblLastname.TabIndex = 0;
			this.lblLastname.Text = "Lastname";
			// 
			// lblFirstname
			// 
			this.lblFirstname.Location = new System.Drawing.Point(148, 68);
			this.lblFirstname.Name = "lblFirstname";
			this.lblFirstname.Size = new System.Drawing.Size(100, 16);
			this.lblFirstname.TabIndex = 1;
			this.lblFirstname.Text = "Firstname";
			// 
			// lblEmail
			// 
			this.lblEmail.Location = new System.Drawing.Point(8, 116);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(100, 16);
			this.lblEmail.TabIndex = 2;
			this.lblEmail.Text = "Email";
			// 
			// lblPhone
			// 
			this.lblPhone.Location = new System.Drawing.Point(148, 116);
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(100, 16);
			this.lblPhone.TabIndex = 3;
			this.lblPhone.Text = "Phone";
			// 
			// lblCreationDate
			// 
			this.lblCreationDate.Location = new System.Drawing.Point(8, 164);
			this.lblCreationDate.Name = "lblCreationDate";
			this.lblCreationDate.Size = new System.Drawing.Size(100, 16);
			this.lblCreationDate.TabIndex = 4;
			this.lblCreationDate.Text = "Created";
			// 
			// lblLastModifiedDate
			// 
			this.lblLastModifiedDate.Location = new System.Drawing.Point(148, 164);
			this.lblLastModifiedDate.Name = "lblLastModifiedDate";
			this.lblLastModifiedDate.Size = new System.Drawing.Size(100, 16);
			this.lblLastModifiedDate.TabIndex = 5;
			this.lblLastModifiedDate.Text = "Last Modified";
			// 
			// txtLastname
			// 
			this.txtLastname.Location = new System.Drawing.Point(8, 84);
			this.txtLastname.Name = "txtLastname";
			this.txtLastname.Size = new System.Drawing.Size(132, 20);
			this.txtLastname.TabIndex = 8;
			this.txtLastname.Text = "";
			// 
			// txtFirstname
			// 
			this.txtFirstname.Location = new System.Drawing.Point(148, 84);
			this.txtFirstname.Name = "txtFirstname";
			this.txtFirstname.Size = new System.Drawing.Size(132, 20);
			this.txtFirstname.TabIndex = 9;
			this.txtFirstname.Text = "";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(8, 132);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(132, 20);
			this.txtEmail.TabIndex = 10;
			this.txtEmail.Text = "";
			// 
			// txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(148, 132);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(132, 20);
			this.txtPhone.TabIndex = 11;
			this.txtPhone.Text = "";
			this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhone_Validating);
			// 
			// txtCreationDate
			// 
			this.txtCreationDate.Location = new System.Drawing.Point(8, 180);
			this.txtCreationDate.Name = "txtCreationDate";
			this.txtCreationDate.ReadOnly = true;
			this.txtCreationDate.Size = new System.Drawing.Size(132, 20);
			this.txtCreationDate.TabIndex = 12;
			this.txtCreationDate.Text = "";
			// 
			// txtLastModifiedDate
			// 
			this.txtLastModifiedDate.Location = new System.Drawing.Point(148, 180);
			this.txtLastModifiedDate.Name = "txtLastModifiedDate";
			this.txtLastModifiedDate.ReadOnly = true;
			this.txtLastModifiedDate.Size = new System.Drawing.Size(132, 20);
			this.txtLastModifiedDate.TabIndex = 13;
			this.txtLastModifiedDate.Text = "";
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																																								this.tbbSave,
																																								this.tbbAdd});
			this.toolBar1.ButtonSize = new System.Drawing.Size(24, 24);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(284, 30);
			this.toolBar1.TabIndex = 14;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbSave
			// 
			this.tbbSave.Tag = "100";
			this.tbbSave.Text = "S";
			this.tbbSave.ToolTipText = "Save the current contact";
			// 
			// lblContactID
			// 
			this.lblContactID.Location = new System.Drawing.Point(4, 40);
			this.lblContactID.Name = "lblContactID";
			this.lblContactID.Size = new System.Drawing.Size(36, 16);
			this.lblContactID.TabIndex = 0;
			this.lblContactID.Text = "ID";
			// 
			// txtContactID
			// 
			this.txtContactID.Location = new System.Drawing.Point(44, 36);
			this.txtContactID.Name = "txtContactID";
			this.txtContactID.ReadOnly = true;
			this.txtContactID.Size = new System.Drawing.Size(52, 20);
			this.txtContactID.TabIndex = 8;
			this.txtContactID.Text = "";
			// 
			// tbbAdd
			// 
			this.tbbAdd.Tag = "110";
			this.tbbAdd.ToolTipText = "Create a new Contact";
			// 
			// frmContact
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(284, 205);
			this.Controls.Add(this.toolBar1);
			this.Controls.Add(this.txtLastModifiedDate);
			this.Controls.Add(this.txtCreationDate);
			this.Controls.Add(this.txtPhone);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.txtFirstname);
			this.Controls.Add(this.txtLastname);
			this.Controls.Add(this.lblLastModifiedDate);
			this.Controls.Add(this.lblCreationDate);
			this.Controls.Add(this.lblPhone);
			this.Controls.Add(this.lblEmail);
			this.Controls.Add(this.lblFirstname);
			this.Controls.Add(this.lblLastname);
			this.Controls.Add(this.lblContactID);
			this.Controls.Add(this.txtContactID);
			this.Name = "frmContact";
			this.Text = "Add/Modify Contact";
			this.ResumeLayout(false);

		}
		#endregion

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(int.Parse(e.Button.Tag.ToString()))
			{
				case 100:	// Save Contact
					try
					{
						if(txtLastname.Text.Trim().Length > 0 && txtFirstname.Text.Trim().Length > 0)
							this.m_oContacts.Save(int.Parse(txtContactID.Text), txtLastname.Text, txtFirstname.Text, txtEmail.Text, txtPhone.Text);
						this.Close();
					}
					catch(Exception eX)
					{
						throw new Exception("Unable to save contact!");
					}
					break;
				case 110:	// Add Contact
					this.ClearBindings();	// Remove the bindings to use the text boxes for simple data entry.
					this.txtContactID.Text = "-1";	// Initialize the Contact ID to negative 1 as cue to CContact to create a new row.
					break;
			}
		}

		private void txtPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(txtPhone.Text == " ")
				return;
		}

		private void InitializeData(int pContactID)
		{
			this.ClearBindings();
			this.m_oContacts.Get();
			if(this.m_oContacts.Data.Rows.Count > 0)
			{
				txtContactID.DataBindings.Add("text", m_oContacts.Data, "contact_id");
				txtLastname.DataBindings.Add("text", m_oContacts.Data, "contact_name_last");
				txtFirstname.DataBindings.Add("text", m_oContacts.Data, "contact_name_first");
				txtEmail.DataBindings.Add("text", m_oContacts.Data, "contact_email");
				txtPhone.DataBindings.Add("text", m_oContacts.Data, "contact_phone");
			}
		}

		private void ClearBindings()
		{
			// Clear the data bindings
			txtContactID.DataBindings.Clear();
			txtLastname.DataBindings.Clear();
			txtFirstname.DataBindings.Clear();
			txtEmail.DataBindings.Clear();
			txtPhone.DataBindings.Clear();

			// Now clear the text from the fields
			txtContactID.Text = txtLastname.Text = txtFirstname.Text = txtEmail.Text = txtPhone.Text = String.Empty;
		}
	}
}
