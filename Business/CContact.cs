using System;
using System.Data;
using System.Data.OleDb;

namespace Business
{
	/// <summary>Class responsible for interacting with the Contacts table.</summary>
	public class CContact : CBusiness
	{
		#region Constructor/Destructor
		public CContact() : base() {}
		public CContact(string pConnectionString) : base(pConnectionString) {}
		public CContact(OleDbConnection pConnection) : base(pConnection) {}
		#endregion
		#region Public methods
		public override void Get()
		{
			//m_oData.SetupCommand("SELECT Contacts.contact_id, Contacts.contact_name_last, Contacts.contact_name_first, (Contacts.contact_name_first+' '+Contacts.contact_name_last) AS contact_name, Contacts.contact_email, Contacts.contact_phone, Contacts.date_created, Contacts.date_last_modified FROM Contacts ORDER BY contact_name_first");
			//m_oData.ExecuteWithRecordset();
		}
		public override void Get(int pID)
		{
			//m_oData.SetupCommand(String.Format("SELECT Contacts.contact_id, Contacts.contact_name_last, Contacts.contact_name_first, (Contacts.contact_name_first+' '+Contacts.contact_name_last) AS contact_name, Contacts.contact_email, Contacts.contact_phone, Contacts.date_created, Contacts.date_last_modified FROM Contacts WHERE Contacts.contact_id={0} ORDER BY contact_name_first", pID));
			//m_oData.ExecuteWithRecordset();
		}
		/// <summary>Saves the passed Contact description to the passed Contact ID if it exists.  If it doesn't exist, creates a new row.</summary>
		/// <param name="pID">ID of the Contact to update (if it exists).</param>
		/// <param name="pDescription">Description to set.</param>
		/// <returns>ID of the modified/created row.</returns>
		public int Save(int pContactID, string pLastName, string pFirstName, string pEmail, string pPhone)
		{
			int iID = (pContactID > 0) ? pContactID : 1;
			try
			{
				using(OleDbDataAdapter oDA		= new OleDbDataAdapter(String.Format("select * from Contacts where contact_id = {0}", pContactID), this.DataObject.ConnectionString))
				using(OleDbCommandBuilder oCB = new OleDbCommandBuilder(oDA))
				using(OleDbConnection oConn		= new OleDbConnection(this.DataObject.ConnectionString))
				{
//					oConn.Open();
					DataSet oDS = new DataSet("Contacts");
					oDA.Fill(oDS);

					if((oDS.Tables[0].Rows.Count > 0) && (pContactID > 0))
					{
						// Should only be one row returned, but go ahead and update all found.
						foreach(DataRow oRow in oDS.Tables[0].Rows)
						{
							if((int)oRow["contact_id"] == pContactID)
							{
								oRow.BeginEdit();
								oRow["contact_name_last"]		= pLastName;
								oRow["contact_name_first"]	= pFirstName;
								oRow["contact_email"]				= pEmail;
								oRow["contact_phone"]				= pPhone;
								oRow["date_last_modified"]	= DateTime.Now;
								oRow.EndEdit();
							}
						}
					}
					else
					{
						// Get our next Contact ID.
						iID = this.DetermineNextID();
						DataRow oRow								= oDS.Tables[0].NewRow();
						oRow["contact_id"]					= iID;
						oRow["contact_name_last"]		= pLastName;
						oRow["contact_name_first"]	= pFirstName;
						oRow["contact_email"]				= pEmail;
						oRow["contact_phone"]				= pPhone;
						oRow["date_created"]				= DateTime.Now;
						oRow["date_last_modified"]	= DateTime.Now;

						oDS.Tables[0].Rows.Add(oRow);
					}

					oDA.Update(oDS);
				}
			}
			catch(Exception e)
			{
				throw new Exception("Unable to save new contact!\nError: " + e.Message);
			}
			return iID;
		}

		/// <summary>Determine the next available Contact ID.</summary>
		/// <returns>Integer representing the next available Contact ID.</returns>
		public override int DetermineNextID()
		{
			this.DataObject.SetupCommand("select max(contact_id)+1 as next_id from Contacts");
			return this.GetNextID();
		}

		#endregion
		#region Private methods
		#endregion
	}
}
