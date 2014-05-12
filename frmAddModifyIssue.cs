using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Business;

namespace Gnosis
{
	/// <summary>Form class representing the User Interface for adding or modifying an issue.</summary>
	public class frmAddModifyIssue : System.Windows.Forms.Form
	{
//		private int					m_iIssueID;
		private CIssue			m_oIssue;
		private CIssueType	m_oIssueTypes;
		private CSystem			m_oSystems;
		private CSubSystem	m_oSubSystems;
		private CSolution		m_oSolution;
		private CContact		m_oContacts;
		private System.Windows.Forms.ComboBox cmbSystems;
		private System.Windows.Forms.ComboBox cmbIssueTypes;
		private System.Windows.Forms.Label lblSolution;
		private System.Windows.Forms.ComboBox cmbSubSystems;
		private System.Windows.Forms.Label lblSystems;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbbSave;
		private System.Windows.Forms.ComboBox cmbContacts;
		private System.Windows.Forms.CheckBox ckbSolved;
		private System.Windows.Forms.TextBox txtIssueDesc;
		private System.Windows.Forms.Label lblIssueType;
		private System.Windows.Forms.Label lblIssueDesc;
		private System.Windows.Forms.Label lblSubSystem;
		private System.Windows.Forms.Label lblContact;
		private System.Windows.Forms.Label lblCauses;
		private System.Windows.Forms.Button btnAddCause;
		private System.Windows.Forms.Button btnEditCause;
		private System.Windows.Forms.Button btnDeleteCause;
		private System.Windows.Forms.Button btnDeleteSolution;
		private System.Windows.Forms.Button btnAddSolution;
		private System.Windows.Forms.Button btnEditSolution;
		private System.Windows.Forms.ListBox lbxCauses;
		private System.Windows.Forms.ListBox lbxSolutions;
		private System.Windows.Forms.ImageList ilPics;
		private System.Windows.Forms.ToolBarButton tbbDeleteIssue;
		private System.ComponentModel.IContainer components;

		#region Properties
		public int IssueID
		{
			get 
			{
				int iIssueID = 0;
				if(this.m_oIssue.Data != null)
					iIssueID = (this.m_oIssue.Data.Rows.Count > 0) ? (int)this.m_oIssue.Data.Rows[0]["issue_id"] : 0; 
				return iIssueID;
			}
		}
		#endregion
		public frmAddModifyIssue()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		public frmAddModifyIssue(CIssue pIssue) : this()
		{
			this.m_oIssue		= pIssue;
			this.BindIssue();
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAddModifyIssue));
			this.cmbSystems = new System.Windows.Forms.ComboBox();
			this.cmbIssueTypes = new System.Windows.Forms.ComboBox();
			this.txtIssueDesc = new System.Windows.Forms.TextBox();
			this.lblSolution = new System.Windows.Forms.Label();
			this.lblIssueType = new System.Windows.Forms.Label();
			this.lblIssueDesc = new System.Windows.Forms.Label();
			this.cmbSubSystems = new System.Windows.Forms.ComboBox();
			this.lblSystems = new System.Windows.Forms.Label();
			this.lblSubSystem = new System.Windows.Forms.Label();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbSave = new System.Windows.Forms.ToolBarButton();
			this.tbbDeleteIssue = new System.Windows.Forms.ToolBarButton();
			this.ilPics = new System.Windows.Forms.ImageList(this.components);
			this.lblContact = new System.Windows.Forms.Label();
			this.cmbContacts = new System.Windows.Forms.ComboBox();
			this.ckbSolved = new System.Windows.Forms.CheckBox();
			this.lblCauses = new System.Windows.Forms.Label();
			this.btnAddCause = new System.Windows.Forms.Button();
			this.btnEditCause = new System.Windows.Forms.Button();
			this.btnDeleteCause = new System.Windows.Forms.Button();
			this.btnDeleteSolution = new System.Windows.Forms.Button();
			this.btnAddSolution = new System.Windows.Forms.Button();
			this.btnEditSolution = new System.Windows.Forms.Button();
			this.lbxCauses = new System.Windows.Forms.ListBox();
			this.lbxSolutions = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// cmbSystems
			// 
			this.cmbSystems.DisplayMember = "system_desc";
			this.cmbSystems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSystems.Location = new System.Drawing.Point(4, 104);
			this.cmbSystems.Name = "cmbSystems";
			this.cmbSystems.Size = new System.Drawing.Size(152, 21);
			this.cmbSystems.TabIndex = 32;
			this.cmbSystems.SelectedIndexChanged += new System.EventHandler(this.cmbSystems_SelectedIndexChanged);
			// 
			// cmbIssueTypes
			// 
			this.cmbIssueTypes.DisplayMember = "issue_type_desc";
			this.cmbIssueTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbIssueTypes.Location = new System.Drawing.Point(4, 60);
			this.cmbIssueTypes.Name = "cmbIssueTypes";
			this.cmbIssueTypes.Size = new System.Drawing.Size(152, 21);
			this.cmbIssueTypes.TabIndex = 31;
			// 
			// txtIssueDesc
			// 
			this.txtIssueDesc.Location = new System.Drawing.Point(4, 152);
			this.txtIssueDesc.Multiline = true;
			this.txtIssueDesc.Name = "txtIssueDesc";
			this.txtIssueDesc.Size = new System.Drawing.Size(508, 44);
			this.txtIssueDesc.TabIndex = 28;
			this.txtIssueDesc.Text = "description";
			// 
			// lblSolution
			// 
			this.lblSolution.Location = new System.Drawing.Point(4, 280);
			this.lblSolution.Name = "lblSolution";
			this.lblSolution.Size = new System.Drawing.Size(68, 16);
			this.lblSolution.TabIndex = 25;
			this.lblSolution.Text = "Solution:";
			// 
			// lblIssueType
			// 
			this.lblIssueType.Location = new System.Drawing.Point(4, 44);
			this.lblIssueType.Name = "lblIssueType";
			this.lblIssueType.Size = new System.Drawing.Size(68, 16);
			this.lblIssueType.TabIndex = 22;
			this.lblIssueType.Text = "Type:";
			// 
			// lblIssueDesc
			// 
			this.lblIssueDesc.Location = new System.Drawing.Point(4, 132);
			this.lblIssueDesc.Name = "lblIssueDesc";
			this.lblIssueDesc.Size = new System.Drawing.Size(68, 16);
			this.lblIssueDesc.TabIndex = 21;
			this.lblIssueDesc.Text = "Description:";
			// 
			// cmbSubSystems
			// 
			this.cmbSubSystems.DisplayMember = "subsystem_desc";
			this.cmbSubSystems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSubSystems.Location = new System.Drawing.Point(360, 104);
			this.cmbSubSystems.Name = "cmbSubSystems";
			this.cmbSubSystems.Size = new System.Drawing.Size(152, 21);
			this.cmbSubSystems.TabIndex = 33;
			// 
			// lblSystems
			// 
			this.lblSystems.Location = new System.Drawing.Point(4, 88);
			this.lblSystems.Name = "lblSystems";
			this.lblSystems.Size = new System.Drawing.Size(68, 16);
			this.lblSystems.TabIndex = 23;
			this.lblSystems.Text = "System:";
			// 
			// lblSubSystem
			// 
			this.lblSubSystem.Location = new System.Drawing.Point(356, 88);
			this.lblSubSystem.Name = "lblSubSystem";
			this.lblSubSystem.Size = new System.Drawing.Size(68, 16);
			this.lblSubSystem.TabIndex = 24;
			this.lblSubSystem.Text = "SubSystem:";
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																																								this.tbbSave,
																																								this.tbbDeleteIssue});
			this.toolBar1.ButtonSize = new System.Drawing.Size(24, 24);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.ilPics;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(516, 30);
			this.toolBar1.TabIndex = 34;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbSave
			// 
			this.tbbSave.ImageIndex = 0;
			this.tbbSave.Tag = "0";
			this.tbbSave.ToolTipText = "Save the issue";
			// 
			// tbbDeleteIssue
			// 
			this.tbbDeleteIssue.ImageIndex = 3;
			this.tbbDeleteIssue.Tag = "999";
			this.tbbDeleteIssue.ToolTipText = "Delete the current Issue";
			// 
			// ilPics
			// 
			this.ilPics.ImageSize = new System.Drawing.Size(16, 16);
			this.ilPics.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPics.ImageStream")));
			this.ilPics.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// lblContact
			// 
			this.lblContact.Location = new System.Drawing.Point(360, 44);
			this.lblContact.Name = "lblContact";
			this.lblContact.Size = new System.Drawing.Size(68, 16);
			this.lblContact.TabIndex = 22;
			this.lblContact.Text = "Contact:";
			// 
			// cmbContacts
			// 
			this.cmbContacts.DisplayMember = "issue_type_desc";
			this.cmbContacts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbContacts.Location = new System.Drawing.Point(360, 60);
			this.cmbContacts.Name = "cmbContacts";
			this.cmbContacts.Size = new System.Drawing.Size(152, 21);
			this.cmbContacts.TabIndex = 31;
			// 
			// ckbSolved
			// 
			this.ckbSolved.Location = new System.Drawing.Point(220, 84);
			this.ckbSolved.Name = "ckbSolved";
			this.ckbSolved.Size = new System.Drawing.Size(76, 16);
			this.ckbSolved.TabIndex = 35;
			this.ckbSolved.Text = "Solved?";
			this.ckbSolved.ThreeState = true;
			// 
			// lblCauses
			// 
			this.lblCauses.Location = new System.Drawing.Point(0, 204);
			this.lblCauses.Name = "lblCauses";
			this.lblCauses.Size = new System.Drawing.Size(68, 16);
			this.lblCauses.TabIndex = 25;
			this.lblCauses.Text = "Cause:";
			// 
			// btnAddCause
			// 
			this.btnAddCause.Location = new System.Drawing.Point(76, 204);
			this.btnAddCause.Name = "btnAddCause";
			this.btnAddCause.Size = new System.Drawing.Size(36, 20);
			this.btnAddCause.TabIndex = 37;
			this.btnAddCause.Text = "&A";
			this.btnAddCause.Click += new System.EventHandler(this.btnAddCause_Click);
			// 
			// btnEditCause
			// 
			this.btnEditCause.Location = new System.Drawing.Point(112, 204);
			this.btnEditCause.Name = "btnEditCause";
			this.btnEditCause.Size = new System.Drawing.Size(36, 20);
			this.btnEditCause.TabIndex = 38;
			this.btnEditCause.Text = "&E";
			this.btnEditCause.Click += new System.EventHandler(this.btnEditCause_Click);
			// 
			// btnDeleteCause
			// 
			this.btnDeleteCause.Location = new System.Drawing.Point(148, 204);
			this.btnDeleteCause.Name = "btnDeleteCause";
			this.btnDeleteCause.Size = new System.Drawing.Size(36, 20);
			this.btnDeleteCause.TabIndex = 39;
			this.btnDeleteCause.Text = "&D";
			this.btnDeleteCause.Click += new System.EventHandler(this.btnDeleteCause_Click);
			// 
			// btnDeleteSolution
			// 
			this.btnDeleteSolution.Location = new System.Drawing.Point(148, 276);
			this.btnDeleteSolution.Name = "btnDeleteSolution";
			this.btnDeleteSolution.Size = new System.Drawing.Size(36, 20);
			this.btnDeleteSolution.TabIndex = 39;
			this.btnDeleteSolution.Text = "&D";
			this.btnDeleteSolution.Click += new System.EventHandler(this.btnDeleteSolution_Click);
			// 
			// btnAddSolution
			// 
			this.btnAddSolution.Location = new System.Drawing.Point(76, 276);
			this.btnAddSolution.Name = "btnAddSolution";
			this.btnAddSolution.Size = new System.Drawing.Size(36, 20);
			this.btnAddSolution.TabIndex = 37;
			this.btnAddSolution.Text = "&A";
			this.btnAddSolution.Click += new System.EventHandler(this.btnAddSolution_Click);
			// 
			// btnEditSolution
			// 
			this.btnEditSolution.Location = new System.Drawing.Point(112, 276);
			this.btnEditSolution.Name = "btnEditSolution";
			this.btnEditSolution.Size = new System.Drawing.Size(36, 20);
			this.btnEditSolution.TabIndex = 38;
			this.btnEditSolution.Text = "&E";
			this.btnEditSolution.Click += new System.EventHandler(this.btnEditSolution_Click);
			// 
			// lbxCauses
			// 
			this.lbxCauses.Location = new System.Drawing.Point(4, 224);
			this.lbxCauses.Name = "lbxCauses";
			this.lbxCauses.Size = new System.Drawing.Size(508, 43);
			this.lbxCauses.TabIndex = 40;
			this.lbxCauses.DoubleClick += new System.EventHandler(this.lbxCauses_DoubleClick);
			// 
			// lbxSolutions
			// 
			this.lbxSolutions.Location = new System.Drawing.Point(4, 300);
			this.lbxSolutions.Name = "lbxSolutions";
			this.lbxSolutions.Size = new System.Drawing.Size(508, 43);
			this.lbxSolutions.TabIndex = 41;
			this.lbxSolutions.DoubleClick += new System.EventHandler(this.lbxSolutions_DoubleClick);
			// 
			// frmAddModifyIssue
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(516, 345);
			this.Controls.Add(this.lbxSolutions);
			this.Controls.Add(this.lbxCauses);
			this.Controls.Add(this.btnDeleteCause);
			this.Controls.Add(this.btnEditCause);
			this.Controls.Add(this.btnAddCause);
			this.Controls.Add(this.ckbSolved);
			this.Controls.Add(this.toolBar1);
			this.Controls.Add(this.cmbSystems);
			this.Controls.Add(this.cmbIssueTypes);
			this.Controls.Add(this.txtIssueDesc);
			this.Controls.Add(this.lblSolution);
			this.Controls.Add(this.lblIssueType);
			this.Controls.Add(this.lblIssueDesc);
			this.Controls.Add(this.cmbSubSystems);
			this.Controls.Add(this.lblSystems);
			this.Controls.Add(this.lblSubSystem);
			this.Controls.Add(this.lblContact);
			this.Controls.Add(this.cmbContacts);
			this.Controls.Add(this.lblCauses);
			this.Controls.Add(this.btnDeleteSolution);
			this.Controls.Add(this.btnAddSolution);
			this.Controls.Add(this.btnEditSolution);
			this.Name = "frmAddModifyIssue";
			this.Text = "Add/Modify Issue";
			this.ResumeLayout(false);

		}
		#endregion

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(int.Parse(e.Button.Tag.ToString()))
			{
				case 0:	// Save
					// BeginTransaction...
					Data.CIssueItem oCurrentIssue		= new Data.CIssueItem();
					oCurrentIssue.IssueDescription	= this.txtIssueDesc.Text;
					oCurrentIssue.IsSolved					= this.ckbSolved.Checked;
					oCurrentIssue.IssueTypeID				= (this.cmbIssueTypes.SelectedValue != null)	? (int)this.cmbIssueTypes.SelectedValue : -1;
					oCurrentIssue.SystemID					= (this.cmbSystems.SelectedValue != null)			? (int)this.cmbSystems.SelectedValue : -1;
					oCurrentIssue.SubSystemID				= (this.cmbSubSystems.SelectedValue != null)	? (int)this.cmbSubSystems.SelectedValue : -1;
					oCurrentIssue.ContactID					= (this.cmbContacts.SelectedValue != null)		? (int)this.cmbContacts.SelectedValue : -1;
					//this.m_iIssueID = 
					m_oIssue.Save(oCurrentIssue);
					// EndTransaction.
					break;
				case 999:	// Delete
					if(MessageBox.Show(String.Format("Are you sure you want to delete issue #{0}?", this.IssueID), "Confirm Issue Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
					{
						// Make sure to delete from the bottom up (Causes, Solutions and then the Issue itself).
						// Delete the current issue
						this.m_oIssue.Delete();
						this.Close();
					}
					break;
			}
		}

		/// <summary>Make the dialog match the state of the data as far as options the user has.</summary>
		private void ToggleDisplay()
		{
			// If we're adding a new issue, make sure the user doesn't try to interact with Causes or Solutions until the issue has been saved.
			if(this.IssueID <= 0)
			{
				this.btnAddCause.Enabled = false;
				this.btnEditCause.Enabled = false;
				this.btnDeleteCause.Enabled = false;
				this.btnAddSolution.Enabled = false;
				this.btnEditSolution.Enabled = false;
				this.btnDeleteSolution.Enabled = false;
			}
			else
			{
				this.btnAddCause.Enabled = true;
				this.btnEditCause.Enabled = true;
				this.btnDeleteCause.Enabled = true;
				this.btnAddSolution.Enabled = true;
				this.btnEditSolution.Enabled = true;
				this.btnDeleteSolution.Enabled = true;
			}
			
			// If we don't have any Causes, disable the Edit and Delete buttons.
			if(this.m_oIssue.Causes != null)
				this.btnEditCause.Enabled = this.btnDeleteCause.Enabled = (this.m_oIssue.Causes.Data.Rows.Count > 0) ? true : false;
			else
				this.btnEditCause.Enabled = this.btnDeleteCause.Enabled = false;

			// If we don't have any Solutions, disable the Edit and Delete buttons.
			if(this.m_oIssue.Solutions != null)
				this.btnEditSolution.Enabled = this.btnDeleteSolution.Enabled = (this.m_oIssue.Solutions.Data.Rows.Count > 0) ? true : false;
			else
				this.btnEditSolution.Enabled = this.btnDeleteSolution.Enabled = false;
			
		}

		private void BindIssue()
		{
			this.InitializeBindings();
			
			if(m_oIssue == null)
			{
				m_oIssue = new CIssue(this.m_oIssue.DataObject.ConnectionString);
				m_oIssue.Get(-1);
			}

			if(m_oIssue.Data != null)
			{
				if(m_oIssue.Data.Rows.Count > 0)
				{
					txtIssueDesc.DataBindings.Add("text", m_oIssue.Data, "issue_desc");
					cmbIssueTypes.DataBindings.Add("text", m_oIssue.Data, "issue_type_desc");
					ckbSolved.DataBindings.Add("checked", m_oIssue.Data, "issue_solved");
					cmbSystems.DataBindings.Add("text", m_oIssue.Data, "system_desc");
					cmbContacts.DataBindings.Add("text", m_oIssue.Data, "contact_name");
					
					this.BindCauses();
					this.BindSolutions();
				}
			}
			else			// Adding new issue, no ID yet.
			{
				this.ToggleDisplay();
			}
			this.cmbSystems_SelectedIndexChanged(null, null);
		}

		private void BindCauses()
		{
			this.m_oIssue.GetCause();
			lbxCauses.DataSource				= m_oIssue.Causes.Data;
			lbxCauses.DisplayMember			= "cause_desc";
			lbxCauses.ValueMember				= "cause_id";
			this.ToggleDisplay();
		}

		private void BindSolutions()
		{
			this.m_oIssue.GetSolution();
			lbxSolutions.DataSource			= m_oIssue.Solutions.Data;
			lbxSolutions.DisplayMember	= "solution_desc";
			lbxSolutions.ValueMember		= "solution_id";
			this.ToggleDisplay();
		}

		private void InitializeBindings()
		{
			this.InitializeIssueTypes();
			this.InitializeContacts();
			this.InitializeSystems();
			this.InitializeSubSystems();
		}
		private void InitializeIssueTypes()
		{
			// Fill the IssueTypes combo box
			cmbIssueTypes.DataBindings.Clear();

			this.m_oIssueTypes = new CIssueType(this.m_oIssue.DataObject.ConnectionString);
			this.m_oIssueTypes.Get();
			
			if(this.m_oIssueTypes.Data.Rows.Count > 0)
			{
				cmbIssueTypes.DataSource = this.m_oIssueTypes.Data;
				cmbIssueTypes.DisplayMember = "issue_type_desc";
				cmbIssueTypes.ValueMember		= "issue_type_id";
			}
		}

		private void InitializeSystems()
		{
			// Fill the Systems combo box
			this.cmbSystems.DataBindings.Clear();
			
			this.m_oSystems = new CSystem(this.m_oIssue.DataObject.ConnectionString);
			this.m_oSystems.Get();
			
			if(this.m_oSystems.Data != null)
			{
				cmbSystems.DataSource			= this.m_oSystems.Data;
				cmbSystems.DisplayMember	= "system_desc";
				cmbSystems.ValueMember		= "system_id";
			}
		}

		private void InitializeContacts()
		{
			// Fill the Contacts combo box
			cmbContacts.DataBindings.Clear();
			this.m_oContacts = new CContact(this.m_oIssue.DataObject.ConnectionString);
			this.m_oContacts.Get();
			if(this.m_oContacts.Data.Rows.Count > 0)
			{
				cmbContacts.DataSource		= this.m_oContacts.Data;
				cmbContacts.DisplayMember = "contact_name";
				cmbContacts.ValueMember		= "contact_id";
			}
		}

		private void InitializeSubSystems()
		{
			// Fill the SubSystems combo box
			this.cmbSubSystems.DataBindings.Clear();
			
			if(this.m_oIssue.Data != null)
			{
				if(Convert.ToInt32(this.cmbSystems.SelectedValue) > 0)
					cmbSubSystems.DataBindings.Add("text", this.m_oIssue.Data, "subsystem_desc");
			}
		}
		
		/// <summary>Populate the list of possible subsystems for the currently selected system.</summary>
		private void GetSubSystems()
		{
			int iSystemID = Convert.ToInt32(cmbSystems.SelectedValue);

			this.cmbSubSystems.DataSource = null;

			// Bind the Issue's subsystem
			if(iSystemID > 0)
			{
				if((int)cmbSystems.SelectedValue > 0)
				{
					this.m_oSubSystems = new CSubSystem(this.m_oIssue.DataObject.ConnectionString);
					this.m_oSubSystems.Get(iSystemID);
					
					// Now populate the combobox with the subsystems to select from.
					if(this.m_oSubSystems.Data != null)
					{
						if(this.m_oSubSystems.Data.Rows.Count > 0)
						{
							cmbSubSystems.DataSource		= this.m_oSubSystems.Data;
							cmbSubSystems.DisplayMember = "subsystem_desc";
							cmbSubSystems.ValueMember		= "subsystem_id";
						}
					}
				}
			}
			this.InitializeSubSystems();
		}

		private void cmbSystems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.GetSubSystems();
		}

		private void btnAddCause_Click(object sender, System.EventArgs e)
		{
			using(frmInputBox oInputBox = new frmInputBox())
			{
				if(oInputBox.ShowMe("Please enter a cause of this issue", "Cause of Issue", false) == DialogResult.OK)
				{
					this.m_oIssue.Causes.Save((int)this.m_oIssue.Data.Rows[0]["issue_id"], 0, oInputBox.Data);
					this.BindCauses();
				}
			}
		}

		private void btnAddSolution_Click(object sender, System.EventArgs e)
		{
			using(frmInputBox oInputBox = new frmInputBox())
			{
//				string sNewSolution = oInputBox.ShowMe("Please enter a solution for this issue", "Solution", false);
//				this.m_oIssue.Solution.Save((int)this.m_oIssue.Data.Rows[0]["issue_id"], 0, sNewSolution);
//				this.BindSolutions();
				if(oInputBox.ShowMe("Please enter a solution for this issue", "Solution", false) == DialogResult.OK)
				{
					this.m_oIssue.Solutions.Save((int)this.m_oIssue.Data.Rows[0]["issue_id"], 0, oInputBox.Data);
					this.BindSolutions();
				}
			}
		}

		private void btnEditSolution_Click(object sender, System.EventArgs e)
		{
			using(frmInputBox oInputBox = new frmInputBox())
			{
				if(oInputBox.ShowMe("Edit solution", "Edit Solution", this.lbxSolutions.Text, false) == DialogResult.OK)
				{
					this.m_oIssue.Solutions.Save((int)this.m_oIssue.Data.Rows[0]["issue_id"], (int)this.lbxSolutions.SelectedValue, oInputBox.Data);
					this.BindSolutions();
				}
			}
		}

		private void btnEditCause_Click(object sender, System.EventArgs e)
		{
			using(frmInputBox oInputBox = new frmInputBox())
			{
				if(oInputBox.ShowMe("Edit Cause", "Edit Cause", this.lbxCauses.Text, false) == DialogResult.OK)
				{
					this.m_oIssue.Causes.Save((int)this.m_oIssue.Data.Rows[0]["issue_id"], (int)this.lbxCauses.SelectedValue, oInputBox.Data);
					this.BindCauses();
				}
			}
		}

		private void btnDeleteCause_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("Are you sure you wish to delete the selected cause from this issue?", "Delete Cause", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				this.m_oIssue.Causes.Delete((int)this.m_oIssue.Data.Rows[0]["issue_id"], (int)this.lbxCauses.SelectedValue);
				this.BindCauses();
			}
		}

		private void btnDeleteSolution_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("Are you sure you wish to delete the selected solution from this issue?", "Delete Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				this.m_oIssue.Solutions.Delete((int)this.m_oIssue.Data.Rows[0]["issue_id"], (int)this.lbxSolutions.SelectedValue);
				this.BindSolutions();
			}
		}

		private void lbxCauses_DoubleClick(object sender, System.EventArgs e)
		{
			using(frmInputBox oInputBox = new frmInputBox())
			{
				oInputBox.ShowMe("View Cause", "View Cause", this.lbxCauses.Text, true);
			}
		}

		private void lbxSolutions_DoubleClick(object sender, System.EventArgs e)
		{
			using(frmInputBox oInputBox = new frmInputBox())
			{
				oInputBox.ShowMe("View Solution", "View Solution", this.lbxSolutions.Text, true);
			}
		}
	}
}
