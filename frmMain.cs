using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Business;

namespace Gnosis
{
	/// <summary>KnowledgeBase of technical issues for development support.</summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private int							m_iIssueIndex;
		private ArrayList				m_aiIssueIds;
		private CIssue					m_oIssue;
		private CIssue					m_oIssueList;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TabPage tbpIssues;
		private System.Windows.Forms.TabPage tbpSearch;
		private System.Windows.Forms.Label lblItemID;
		private System.Windows.Forms.Label lblItemDesc;
		private System.Windows.Forms.Label lblItemType;
		private System.Windows.Forms.Label lblDateCreated;
		private System.Windows.Forms.TextBox txtDateCreated;
		private System.Windows.Forms.Label lblSearchText;
		private System.Windows.Forms.ListBox lbResultingItems;
		private System.Windows.Forms.Label lblResultingItems;
		private System.Windows.Forms.Label lblFoundItemsCounter;
		private System.Windows.Forms.TextBox txtSearchExpression;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem miFile;
		private System.Windows.Forms.MenuItem miExit;
		private System.Windows.Forms.MenuItem miSeparator01;
		private System.Windows.Forms.Label lblSolution;
		private System.Windows.Forms.Label lblSystems;
		private System.Windows.Forms.Label label2;
		private System.Data.OleDb.OleDbConnection DbConn;
		private Gnosis.sqldsIssues sqldsIssues;
		private System.Windows.Forms.Label lblDateLastModified;
		private System.Windows.Forms.TextBox txtDateLastModified;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbbAdd;
		private System.Windows.Forms.ToolBarButton tbbModify;
		private System.Windows.Forms.TextBox txtContact;
		private System.Windows.Forms.Label lblContact;
		private System.Windows.Forms.TextBox txtIssueDesc;
		private System.Windows.Forms.TextBox txtIssueID;
		private System.Windows.Forms.CheckBox ckbSolved;
		private System.Windows.Forms.TextBox txtIssueType;
		private System.Windows.Forms.TextBox txtSystem;
		private System.Windows.Forms.TextBox txtSubSystem;
		private System.Windows.Forms.Label lblCause;
		private System.Windows.Forms.HScrollBar hScrollBar1;
		private System.Windows.Forms.ListBox lbxCauses;
		private System.Windows.Forms.ListBox lbxSolutions;
		private System.Windows.Forms.ImageList ilPics;
		private System.Windows.Forms.MenuItem miAddIssue;
		private System.Windows.Forms.MenuItem miDeleteIssue;
		private System.Windows.Forms.MenuItem miEditIssue;
		private System.Windows.Forms.MenuItem miEdit;
		private System.Windows.Forms.MenuItem miContact;
		private System.Windows.Forms.MenuItem miSystems;
		private System.Windows.Forms.MenuItem miIssueTypes;
		private System.ComponentModel.IContainer components;

		public frmMain()
		{
			InitializeComponent();

			this.m_iIssueIndex	= 0;
			this.m_oIssue				= new CIssue();
			this.m_oIssueList		= new CIssue();
			// Perform the initial data retrieval, gather the data necessary and display it
			Initialize();
		}

		/// <summary>Clean up any resources being used.</summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tbpIssues = new System.Windows.Forms.TabPage();
			this.lbxSolutions = new System.Windows.Forms.ListBox();
			this.lbxCauses = new System.Windows.Forms.ListBox();
			this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
			this.ckbSolved = new System.Windows.Forms.CheckBox();
			this.txtDateCreated = new System.Windows.Forms.TextBox();
			this.txtIssueDesc = new System.Windows.Forms.TextBox();
			this.txtIssueID = new System.Windows.Forms.TextBox();
			this.lblDateCreated = new System.Windows.Forms.Label();
			this.lblSolution = new System.Windows.Forms.Label();
			this.lblItemType = new System.Windows.Forms.Label();
			this.lblItemDesc = new System.Windows.Forms.Label();
			this.lblItemID = new System.Windows.Forms.Label();
			this.lblSystems = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblDateLastModified = new System.Windows.Forms.Label();
			this.txtDateLastModified = new System.Windows.Forms.TextBox();
			this.txtContact = new System.Windows.Forms.TextBox();
			this.lblContact = new System.Windows.Forms.Label();
			this.txtIssueType = new System.Windows.Forms.TextBox();
			this.txtSystem = new System.Windows.Forms.TextBox();
			this.txtSubSystem = new System.Windows.Forms.TextBox();
			this.lblCause = new System.Windows.Forms.Label();
			this.tbpSearch = new System.Windows.Forms.TabPage();
			this.btnSearch = new System.Windows.Forms.Button();
			this.lblFoundItemsCounter = new System.Windows.Forms.Label();
			this.lblResultingItems = new System.Windows.Forms.Label();
			this.lbResultingItems = new System.Windows.Forms.ListBox();
			this.txtSearchExpression = new System.Windows.Forms.TextBox();
			this.lblSearchText = new System.Windows.Forms.Label();
			this.sqldsIssues = new Gnosis.sqldsIssues();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.miFile = new System.Windows.Forms.MenuItem();
			this.miAddIssue = new System.Windows.Forms.MenuItem();
			this.miEditIssue = new System.Windows.Forms.MenuItem();
			this.miDeleteIssue = new System.Windows.Forms.MenuItem();
			this.miSeparator01 = new System.Windows.Forms.MenuItem();
			this.miExit = new System.Windows.Forms.MenuItem();
			this.DbConn = new System.Data.OleDb.OleDbConnection();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbAdd = new System.Windows.Forms.ToolBarButton();
			this.tbbModify = new System.Windows.Forms.ToolBarButton();
			this.ilPics = new System.Windows.Forms.ImageList(this.components);
			this.miEdit = new System.Windows.Forms.MenuItem();
			this.miContact = new System.Windows.Forms.MenuItem();
			this.miSystems = new System.Windows.Forms.MenuItem();
			this.miIssueTypes = new System.Windows.Forms.MenuItem();
			this.tabControl1.SuspendLayout();
			this.tbpIssues.SuspendLayout();
			this.tbpSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sqldsIssues)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tbpIssues);
			this.tabControl1.Controls.Add(this.tbpSearch);
			this.tabControl1.Location = new System.Drawing.Point(4, 36);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(596, 324);
			this.tabControl1.TabIndex = 1;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tbpIssues
			// 
			this.tbpIssues.Controls.Add(this.lbxSolutions);
			this.tbpIssues.Controls.Add(this.lbxCauses);
			this.tbpIssues.Controls.Add(this.hScrollBar1);
			this.tbpIssues.Controls.Add(this.ckbSolved);
			this.tbpIssues.Controls.Add(this.txtDateCreated);
			this.tbpIssues.Controls.Add(this.txtIssueDesc);
			this.tbpIssues.Controls.Add(this.txtIssueID);
			this.tbpIssues.Controls.Add(this.lblDateCreated);
			this.tbpIssues.Controls.Add(this.lblSolution);
			this.tbpIssues.Controls.Add(this.lblItemType);
			this.tbpIssues.Controls.Add(this.lblItemDesc);
			this.tbpIssues.Controls.Add(this.lblItemID);
			this.tbpIssues.Controls.Add(this.lblSystems);
			this.tbpIssues.Controls.Add(this.label2);
			this.tbpIssues.Controls.Add(this.lblDateLastModified);
			this.tbpIssues.Controls.Add(this.txtDateLastModified);
			this.tbpIssues.Controls.Add(this.txtContact);
			this.tbpIssues.Controls.Add(this.lblContact);
			this.tbpIssues.Controls.Add(this.txtIssueType);
			this.tbpIssues.Controls.Add(this.txtSystem);
			this.tbpIssues.Controls.Add(this.txtSubSystem);
			this.tbpIssues.Controls.Add(this.lblCause);
			this.tbpIssues.Location = new System.Drawing.Point(4, 22);
			this.tbpIssues.Name = "tbpIssues";
			this.tbpIssues.Size = new System.Drawing.Size(588, 298);
			this.tbpIssues.TabIndex = 0;
			this.tbpIssues.Text = "Issues";
			// 
			// lbxSolutions
			// 
			this.lbxSolutions.Location = new System.Drawing.Point(72, 224);
			this.lbxSolutions.Name = "lbxSolutions";
			this.lbxSolutions.Size = new System.Drawing.Size(512, 43);
			this.lbxSolutions.TabIndex = 24;
			this.toolTip1.SetToolTip(this.lbxSolutions, "Solution(s) to the issue");
			this.lbxSolutions.DoubleClick += new System.EventHandler(this.lbxSolutions_DoubleClick);
			// 
			// lbxCauses
			// 
			this.lbxCauses.Location = new System.Drawing.Point(72, 172);
			this.lbxCauses.Name = "lbxCauses";
			this.lbxCauses.Size = new System.Drawing.Size(512, 43);
			this.lbxCauses.TabIndex = 23;
			this.lbxCauses.DoubleClick += new System.EventHandler(this.lbxCauses_DoubleClick);
			// 
			// hScrollBar1
			// 
			this.hScrollBar1.Location = new System.Drawing.Point(0, 280);
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new System.Drawing.Size(588, 16);
			this.hScrollBar1.TabIndex = 22;
			this.toolTip1.SetToolTip(this.hScrollBar1, "Issue navigation scrollbar (steps through the list of issues)");
			this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
			// 
			// ckbSolved
			// 
			this.ckbSolved.Enabled = false;
			this.ckbSolved.Location = new System.Drawing.Point(516, 6);
			this.ckbSolved.Name = "ckbSolved";
			this.ckbSolved.Size = new System.Drawing.Size(60, 16);
			this.ckbSolved.TabIndex = 20;
			this.ckbSolved.Text = "Solved";
			this.ckbSolved.ThreeState = true;
			// 
			// txtDateCreated
			// 
			this.txtDateCreated.Location = new System.Drawing.Point(424, 34);
			this.txtDateCreated.Name = "txtDateCreated";
			this.txtDateCreated.ReadOnly = true;
			this.txtDateCreated.Size = new System.Drawing.Size(156, 20);
			this.txtDateCreated.TabIndex = 9;
			this.txtDateCreated.Text = "date";
			// 
			// txtIssueDesc
			// 
			this.txtIssueDesc.Location = new System.Drawing.Point(72, 120);
			this.txtIssueDesc.Multiline = true;
			this.txtIssueDesc.Name = "txtIssueDesc";
			this.txtIssueDesc.Size = new System.Drawing.Size(512, 44);
			this.txtIssueDesc.TabIndex = 7;
			this.txtIssueDesc.Text = "description";
			this.txtIssueDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIssueDesc_KeyPress);
			// 
			// txtIssueID
			// 
			this.txtIssueID.Location = new System.Drawing.Point(72, 4);
			this.txtIssueID.Name = "txtIssueID";
			this.txtIssueID.ReadOnly = true;
			this.txtIssueID.Size = new System.Drawing.Size(60, 20);
			this.txtIssueID.TabIndex = 6;
			this.txtIssueID.Text = "0";
			this.txtIssueID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblDateCreated
			// 
			this.lblDateCreated.Location = new System.Drawing.Point(340, 36);
			this.lblDateCreated.Name = "lblDateCreated";
			this.lblDateCreated.Size = new System.Drawing.Size(76, 16);
			this.lblDateCreated.TabIndex = 4;
			this.lblDateCreated.Text = "Date Created:";
			// 
			// lblSolution
			// 
			this.lblSolution.Location = new System.Drawing.Point(4, 224);
			this.lblSolution.Name = "lblSolution";
			this.lblSolution.Size = new System.Drawing.Size(68, 16);
			this.lblSolution.TabIndex = 3;
			this.lblSolution.Text = "Solution:";
			// 
			// lblItemType
			// 
			this.lblItemType.Location = new System.Drawing.Point(4, 36);
			this.lblItemType.Name = "lblItemType";
			this.lblItemType.Size = new System.Drawing.Size(68, 16);
			this.lblItemType.TabIndex = 2;
			this.lblItemType.Text = "Type:";
			// 
			// lblItemDesc
			// 
			this.lblItemDesc.Location = new System.Drawing.Point(4, 120);
			this.lblItemDesc.Name = "lblItemDesc";
			this.lblItemDesc.Size = new System.Drawing.Size(68, 16);
			this.lblItemDesc.TabIndex = 1;
			this.lblItemDesc.Text = "Description:";
			// 
			// lblItemID
			// 
			this.lblItemID.Location = new System.Drawing.Point(4, 8);
			this.lblItemID.Name = "lblItemID";
			this.lblItemID.Size = new System.Drawing.Size(24, 16);
			this.lblItemID.TabIndex = 0;
			this.lblItemID.Text = "ID:";
			// 
			// lblSystems
			// 
			this.lblSystems.Location = new System.Drawing.Point(4, 62);
			this.lblSystems.Name = "lblSystems";
			this.lblSystems.Size = new System.Drawing.Size(68, 16);
			this.lblSystems.TabIndex = 2;
			this.lblSystems.Text = "System:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "SubSystem:";
			// 
			// lblDateLastModified
			// 
			this.lblDateLastModified.Location = new System.Drawing.Point(340, 62);
			this.lblDateLastModified.Name = "lblDateLastModified";
			this.lblDateLastModified.Size = new System.Drawing.Size(76, 16);
			this.lblDateLastModified.TabIndex = 4;
			this.lblDateLastModified.Text = "Last Modified:";
			// 
			// txtDateLastModified
			// 
			this.txtDateLastModified.Location = new System.Drawing.Point(424, 60);
			this.txtDateLastModified.Name = "txtDateLastModified";
			this.txtDateLastModified.ReadOnly = true;
			this.txtDateLastModified.Size = new System.Drawing.Size(156, 20);
			this.txtDateLastModified.TabIndex = 9;
			this.txtDateLastModified.Text = "date";
			// 
			// txtContact
			// 
			this.txtContact.Location = new System.Drawing.Point(424, 88);
			this.txtContact.Name = "txtContact";
			this.txtContact.ReadOnly = true;
			this.txtContact.Size = new System.Drawing.Size(156, 20);
			this.txtContact.TabIndex = 9;
			this.txtContact.Text = "contact";
			this.txtContact.TextChanged += new System.EventHandler(this.txtContact_TextChanged);
			// 
			// lblContact
			// 
			this.lblContact.Location = new System.Drawing.Point(340, 90);
			this.lblContact.Name = "lblContact";
			this.lblContact.Size = new System.Drawing.Size(76, 16);
			this.lblContact.TabIndex = 4;
			this.lblContact.Text = "Contact:";
			this.lblContact.Click += new System.EventHandler(this.lblContact_Click);
			// 
			// txtIssueType
			// 
			this.txtIssueType.Location = new System.Drawing.Point(72, 34);
			this.txtIssueType.Name = "txtIssueType";
			this.txtIssueType.ReadOnly = true;
			this.txtIssueType.Size = new System.Drawing.Size(156, 20);
			this.txtIssueType.TabIndex = 9;
			this.txtIssueType.Text = "issue_type_desc";
			// 
			// txtSystem
			// 
			this.txtSystem.Location = new System.Drawing.Point(72, 60);
			this.txtSystem.Name = "txtSystem";
			this.txtSystem.ReadOnly = true;
			this.txtSystem.Size = new System.Drawing.Size(156, 20);
			this.txtSystem.TabIndex = 9;
			this.txtSystem.Text = "system_desc";
			// 
			// txtSubSystem
			// 
			this.txtSubSystem.Location = new System.Drawing.Point(72, 88);
			this.txtSubSystem.Name = "txtSubSystem";
			this.txtSubSystem.ReadOnly = true;
			this.txtSubSystem.Size = new System.Drawing.Size(156, 20);
			this.txtSubSystem.TabIndex = 9;
			this.txtSubSystem.Text = "subsystem_desc";
			// 
			// lblCause
			// 
			this.lblCause.Location = new System.Drawing.Point(4, 172);
			this.lblCause.Name = "lblCause";
			this.lblCause.Size = new System.Drawing.Size(68, 16);
			this.lblCause.TabIndex = 3;
			this.lblCause.Text = "Cause:";
			// 
			// tbpSearch
			// 
			this.tbpSearch.Controls.Add(this.btnSearch);
			this.tbpSearch.Controls.Add(this.lblFoundItemsCounter);
			this.tbpSearch.Controls.Add(this.lblResultingItems);
			this.tbpSearch.Controls.Add(this.lbResultingItems);
			this.tbpSearch.Controls.Add(this.txtSearchExpression);
			this.tbpSearch.Controls.Add(this.lblSearchText);
			this.tbpSearch.Location = new System.Drawing.Point(4, 22);
			this.tbpSearch.Name = "tbpSearch";
			this.tbpSearch.Size = new System.Drawing.Size(588, 298);
			this.tbpSearch.TabIndex = 1;
			this.tbpSearch.Text = "Search";
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(116, 4);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(48, 20);
			this.btnSearch.TabIndex = 5;
			this.btnSearch.Text = "&Go!";
			// 
			// lblFoundItemsCounter
			// 
			this.lblFoundItemsCounter.Location = new System.Drawing.Point(448, 276);
			this.lblFoundItemsCounter.Name = "lblFoundItemsCounter";
			this.lblFoundItemsCounter.Size = new System.Drawing.Size(136, 16);
			this.lblFoundItemsCounter.TabIndex = 4;
			this.lblFoundItemsCounter.Text = "0 items found";
			this.lblFoundItemsCounter.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblResultingItems
			// 
			this.lblResultingItems.Location = new System.Drawing.Point(4, 56);
			this.lblResultingItems.Name = "lblResultingItems";
			this.lblResultingItems.Size = new System.Drawing.Size(100, 16);
			this.lblResultingItems.TabIndex = 3;
			this.lblResultingItems.Text = "&Results";
			// 
			// lbResultingItems
			// 
			this.lbResultingItems.Location = new System.Drawing.Point(4, 72);
			this.lbResultingItems.Name = "lbResultingItems";
			this.lbResultingItems.Size = new System.Drawing.Size(580, 199);
			this.lbResultingItems.TabIndex = 2;
			// 
			// txtSearchExpression
			// 
			this.txtSearchExpression.Location = new System.Drawing.Point(4, 24);
			this.txtSearchExpression.Name = "txtSearchExpression";
			this.txtSearchExpression.Size = new System.Drawing.Size(580, 20);
			this.txtSearchExpression.TabIndex = 1;
			this.txtSearchExpression.Text = "search expression";
			// 
			// lblSearchText
			// 
			this.lblSearchText.Location = new System.Drawing.Point(4, 4);
			this.lblSearchText.Name = "lblSearchText";
			this.lblSearchText.Size = new System.Drawing.Size(108, 16);
			this.lblSearchText.TabIndex = 0;
			this.lblSearchText.Text = "&Search Expression:";
			// 
			// sqldsIssues
			// 
			this.sqldsIssues.DataSetName = "sqldsIssues";
			this.sqldsIssues.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.miFile,
																																							this.miEdit});
			// 
			// miFile
			// 
			this.miFile.Index = 0;
			this.miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																					 this.miAddIssue,
																																					 this.miEditIssue,
																																					 this.miDeleteIssue,
																																					 this.miSeparator01,
																																					 this.miExit});
			this.miFile.Text = "&File";
			// 
			// miAddIssue
			// 
			this.miAddIssue.Index = 0;
			this.miAddIssue.Text = "Add Issue/Information";
			this.miAddIssue.Click += new System.EventHandler(this.miNewKnowledge_Click);
			// 
			// miEditIssue
			// 
			this.miEditIssue.Index = 1;
			this.miEditIssue.Text = "&Edit Issue/Information";
			// 
			// miDeleteIssue
			// 
			this.miDeleteIssue.Index = 2;
			this.miDeleteIssue.Text = "&Delete Issue/Information";
			this.miDeleteIssue.Click += new System.EventHandler(this.miDeleteKnowledge_Click);
			// 
			// miSeparator01
			// 
			this.miSeparator01.Index = 3;
			this.miSeparator01.Text = "-";
			// 
			// miExit
			// 
			this.miExit.Index = 4;
			this.miExit.Text = "E&xit";
			this.miExit.Click += new System.EventHandler(this.miExit_Click);
			// 
			// DbConn
			// 
			this.DbConn.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=;Data Source=""D:\PNO\Projects\C#\Gnosis\Gnosis.mdb"";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False";
			// 
			// toolBar1
			// 
			this.toolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																																								this.tbbAdd,
																																								this.tbbModify});
			this.toolBar1.ButtonSize = new System.Drawing.Size(24, 24);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.ilPics;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(602, 31);
			this.toolBar1.TabIndex = 2;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbAdd
			// 
			this.tbbAdd.ImageIndex = 1;
			this.tbbAdd.Tag = "110";
			this.tbbAdd.ToolTipText = "Create a new Issue";
			// 
			// tbbModify
			// 
			this.tbbModify.ImageIndex = 2;
			this.tbbModify.Tag = "120";
			this.tbbModify.ToolTipText = "Edit the current Issue";
			// 
			// ilPics
			// 
			this.ilPics.ImageSize = new System.Drawing.Size(16, 16);
			this.ilPics.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPics.ImageStream")));
			this.ilPics.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// miEdit
			// 
			this.miEdit.Index = 1;
			this.miEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																					 this.miContact,
																																					 this.miIssueTypes,
																																					 this.miSystems});
			this.miEdit.Text = "&Edit";
			// 
			// miContact
			// 
			this.miContact.Index = 0;
			this.miContact.Text = "Maintain &Contacts";
			this.miContact.Click += new System.EventHandler(this.miContact_Click);
			// 
			// miSystems
			// 
			this.miSystems.Index = 2;
			this.miSystems.Text = "Maintain Systems";
			// 
			// miIssueTypes
			// 
			this.miIssueTypes.Index = 1;
			this.miIssueTypes.Text = "Maintain Issue Types";
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(602, 363);
			this.Controls.Add(this.toolBar1);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Menu = this.mainMenu1;
			this.Name = "frmMain";
			this.Text = "KnowledgeBase";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMain_KeyPress);
			this.tabControl1.ResumeLayout(false);
			this.tbpIssues.ResumeLayout(false);
			this.tbpSearch.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sqldsIssues)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>Main</summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void Initialize()
		{
			this.GetIssueList(0);
			this.BindIssue();
			this.InitializeScrollBar();
		}

		private void GetIssueList(int pCurrentIssueID)
		{
			this.m_aiIssueIds = new ArrayList();
			//Data.CDatabaseOLE oDb = new Data.CDatabaseOLE(this.DbConn.ConnectionString);
			oDb.SetupCommand("select issue_id from Issues order by issue_id");
			oDb.ExecuteWithRecordset();
			for(int i = 0; i < oDb.RecordSet.Rows.Count; i++)
			{
				DataRow oRow = oDb.RecordSet.Rows[i];
				this.m_aiIssueIds.Add(oRow[0]);
				if((pCurrentIssueID > 0) && ((int)oRow["issue_id"] == pCurrentIssueID))
					this.m_iIssueIndex = i;
			}
		}

		void BindIssue()
		{
			m_oIssue = new CIssue(DbConn.ConnectionString);
			m_oIssue.Get(Convert.ToInt16(this.m_aiIssueIds[m_iIssueIndex]));
			
			this.ClearBindings();

			if(m_oIssue.Data.Rows.Count > 0)
			{
				txtIssueID.DataBindings.Add("text", m_oIssue.Data, "issue_id");
				txtDateCreated.DataBindings.Add("text", m_oIssue.Data, "date_created");
				txtDateLastModified.DataBindings.Add("text", m_oIssue.Data, "date_last_modified");
				txtIssueDesc.DataBindings.Add("text", m_oIssue.Data, "issue_desc");
				txtIssueType.DataBindings.Add("text", m_oIssue.Data, "issue_type_desc");
				txtSystem.DataBindings.Add("text", m_oIssue.Data, "system_desc");
				txtSubSystem.DataBindings.Add("text", m_oIssue.Data, "subsystem_desc");
				txtContact.DataBindings.Add("text", m_oIssue.Data, "contact_name");
				ckbSolved.DataBindings.Add("checked", m_oIssue.Data, "issue_solved");

				lbxCauses.DataSource				= m_oIssue.Causes.Data;
				lbxCauses.DisplayMember			= "cause_desc";
				lbxCauses.ValueMember				= "cause_id";

				lbxSolutions.DataSource			= m_oIssue.Solutions.Data;
				lbxSolutions.DisplayMember	= "solution_desc";
				lbxSolutions.ValueMember		= "solution_id";
			}
		}

		private void ClearBindings()
		{
			txtIssueID.DataBindings.Clear();
			txtDateCreated.DataBindings.Clear();
			txtDateLastModified.DataBindings.Clear();
			txtIssueDesc.DataBindings.Clear();
			txtIssueType.DataBindings.Clear();
			txtSystem.DataBindings.Clear();
			txtSubSystem.DataBindings.Clear();
			txtContact.DataBindings.Clear();
			ckbSolved.DataBindings.Clear();
		}

		#region Menu Processing
		private void miExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void miNewKnowledge_Click(object sender, System.EventArgs e)
		{
//			CItem oItem = new CItem();	//(txtItemDesc.Text, txtWisdom.Text));
		}

		private void miSaveKnowledge_Click(object sender, System.EventArgs e)
		{
		
		}

		private void miDeleteKnowledge_Click(object sender, System.EventArgs e)
		{
		
		}
		#endregion

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnSkipForward_Click(object sender, System.EventArgs e)
		{
			m_iIssueIndex += (m_iIssueIndex < this.m_aiIssueIds.Count - 1) ? 1 : 0;
			this.BindIssue();
		}

		private void btnSkipBackward_Click(object sender, System.EventArgs e)
		{
			m_iIssueIndex -= (m_iIssueIndex > 0) ? 1 : 0;
			this.BindIssue();
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(int.Parse(e.Button.Tag.ToString()))
			{
				case 110:	// Add
					using(frmAddModifyIssue frmAMIssue = new frmAddModifyIssue(new CIssue(this.DbConn.ConnectionString)))
					{
						frmAMIssue.ShowDialog();
						this.GetIssueList(frmAMIssue.IssueID);
					}
					this.BindIssue();
					this.InitializeScrollBar();
					break;
				case 120:	// Modify
					using(frmAddModifyIssue frmAMIssue = new frmAddModifyIssue(this.m_oIssue))
					{
						frmAMIssue.ShowDialog();
					}
					this.BindIssue();
					break;
//				case 130:	// Delete
//					if(MessageBox.Show(String.Format("Are you sure you want to delete issue #{0}?", this.m_aiIssueIds[this.m_iIssueIndex]), "Confirm Issue Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
//					{
//						// Make sure to delete from the bottom up (Causes, Solutions and then the Issue itself).
//						// Delete the current issue
//						this.m_oIssue.Delete();
//						// Remove it from our quick-n-dirty array of IDs
//						this.m_aiIssueIds.Remove(m_iIssueIndex);
//						// Reset (if necessary) our array index to point to a valid issue for redisplay
//						m_iIssueIndex = ((m_iIssueIndex < m_aiIssueIds.Count-1) && (m_iIssueIndex >= 0)) ? m_iIssueIndex: 0;
//						// Now display the valid issue instead of the one we just deleted
//						this.BindIssue();
//					}
//					break;
			}
		}

		private void txtContact_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lblContact_Click(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>Navigation between saved issues.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void hScrollBar1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			// Move to the next Issue
			if(e.NewValue > this.hScrollBar1.Value)
			{
				this.m_iIssueIndex = (this.m_iIssueIndex < this.m_aiIssueIds.Count-1) ? ++this.m_iIssueIndex : this.m_iIssueIndex;
				this.BindIssue();
			}
			else if((e.NewValue < this.hScrollBar1.Value) && (e.NewValue > 0))	// Move to the previous Issue
			{
				this.m_iIssueIndex = (this.m_iIssueIndex > 0) ? --this.m_iIssueIndex : this.m_iIssueIndex;
				this.BindIssue();
			}
		}

		private void InitializeScrollBar()
		{
			this.hScrollBar1.Minimum = 0;
			this.hScrollBar1.Maximum = this.m_aiIssueIds.Count;
			this.hScrollBar1.SmallChange = this.hScrollBar1.LargeChange = 1;
		}

		private void lbxSolutions_DoubleClick(object sender, System.EventArgs e)
		{
			using(frmInputBox oInputBox = new frmInputBox())
			{
				oInputBox.ShowMe("View Solution", "View Solution", this.lbxSolutions.Text, true);
			}
		}

		private void lbxCauses_DoubleClick(object sender, System.EventArgs e)
		{
			using(frmInputBox oInputBox = new frmInputBox())
			{
				oInputBox.ShowMe("View Cause", "View Cause", this.lbxCauses.Text, true);
			}
		}

		/// <summary>I want the Issue Description textbox to be ReadOnly, but I don't want it's appearance changed.
		/// Therefore, just throw away any key presses.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtIssueDesc_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void frmMain_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			//			System.Text.StringBuilder sbKeys = new System.Text.StringBuilder();
			//			if(Control.ModifierKeys == Keys.Control)	sbKeys.Append("Ctrl");
			//			if(Control.ModifierKeys == Keys.Shift)		sbKeys.Append("Shift");
			//			if(Control.ModifierKeys == Keys.Alt)			sbKeys.Append("Alt");
			//			if(sbKeys.Length > 0) sbKeys.Append("-");
			//			sbKeys.Append(e.KeyChar);
			//			MessageBox.Show(sbKeys.ToString(), "KeyPress Event");
			//
			//			// We want to allow Ctrl-C to still operate as normal (so we can copy the data out of the fields if necessary).
			//			// No other keypresses allowed.
			//			if((Control.ModifierKeys == Keys.Control) && ((e.KeyChar == (char)67)||(e.KeyChar == (char)99)))
			//				MessageBox.Show("You pressed Ctrl-C");
			//			else
		}

		private void miContact_Click(object sender, System.EventArgs e)
		{
			using(frmContact oContact = new frmContact(this.m_oIssue.DataObject.ConnectionString))
			{
				oContact.ShowDialog();
			}
		}
	}
}
