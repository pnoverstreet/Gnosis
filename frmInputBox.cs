using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Gnosis
{
	/// <summary>Form representing a generic text input dialog.</summary>
	public sealed class frmInputBox : System.Windows.Forms.Form
	{
		private bool	m_bIsReadOnly;
		private System.Windows.Forms.Label lblPrompt;
		private System.Windows.Forms.TextBox txtInputBox;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>Required designer variable.</summary>
		private System.ComponentModel.Container components = null;

		public frmInputBox()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.m_bIsReadOnly = false;
		}
		/// <summary>Overloaded constructor</summary>
		/// <param name="pPrompt">String representing the question the user should be presented with for confirmation.</param>
		/// <param name="pCaption">String representing the window title.</param>
		/// <param name="pData"/>String representing the contents of the textbox (for editing existing strings).
		/// <param name="pReadOnly">Boolean indicating whether or not the the value is editable.</param>
		public frmInputBox(string pPrompt, string pCaption, string pData, bool pIsReadOnly) : this()
		{
			this.Prompt				= pPrompt;
			this.Caption			= pCaption;
			this.Data					= pData;
			this.IsReadOnly		= pIsReadOnly;
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
			this.lblPrompt = new System.Windows.Forms.Label();
			this.txtInputBox = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblPrompt
			// 
			this.lblPrompt.Location = new System.Drawing.Point(4, 4);
			this.lblPrompt.Name = "lblPrompt";
			this.lblPrompt.Size = new System.Drawing.Size(504, 16);
			this.lblPrompt.TabIndex = 0;
			this.lblPrompt.Text = "Prompt";
			// 
			// txtInputBox
			// 
			this.txtInputBox.Location = new System.Drawing.Point(4, 20);
			this.txtInputBox.Multiline = true;
			this.txtInputBox.Name = "txtInputBox";
			this.txtInputBox.Size = new System.Drawing.Size(504, 68);
			this.txtInputBox.TabIndex = 1;
			this.txtInputBox.Text = "";
			this.txtInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputBox_KeyPress);
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(179, 96);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "Ok";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(256, 96);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmInputBox
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(510, 123);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txtInputBox);
			this.Controls.Add(this.lblPrompt);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmInputBox";
			this.Text = "Input Box";
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		/// <summary>Property: String representing the user prompt which should be displayed in a label on the form asking the user for the data.</summary>
		public string Prompt
		{
			get { return this.lblPrompt.Text; }
			set { this.lblPrompt.Text = value; }
		}
		/// <summary>Property: String representing the caption which should display at the top of the form.</summary>
		public string Caption
		{
			get { return this.Text; }
			set { this.Text = value; }
		}
		/// <summary>Property: String representing the data to be displayed in the textbox.</summary>
		public string Data
		{
			get { return this.txtInputBox.Text; }
			set { this.txtInputBox.Text = value; }
		}
		/// <summary>Property: Boolean representing whether or not the text in the textbox is editable by the user.</summary>
		public bool IsReadOnly
		{
			get { return this.m_bIsReadOnly; }
			set { this.m_bIsReadOnly = value; }
		}
		#endregion
		#region Public methods
		private void btnOk_Click(object sender, System.EventArgs e)
		{
		}
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		public DialogResult ShowMe(string pPrompt, string pCaption, bool pIsReadOnly)
		{
			this.Caption		= pCaption;
			this.Prompt			= pPrompt;
			this.IsReadOnly	= pIsReadOnly;
			this.ShowDialog();
			return this.DialogResult;
		}

		/// <summary>If the intent is to merely view data without the desire to change it, just throw away any key presses.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtInputBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(this.IsReadOnly)
				e.Handled = true;
		}

		public DialogResult ShowMe(string pPrompt, string pCaption, string pData, bool pIsReadOnly)
		{
			this.Data = (pData);
			this.ShowMe(pPrompt, pCaption, pIsReadOnly);
			return this.DialogResult;
		}
		#endregion
	}
}
