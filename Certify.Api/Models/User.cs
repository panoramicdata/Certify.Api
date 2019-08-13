using Certify.Api.Interfaces;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// User
	/// </summary>
	[DataContract]
	public class User : IdentifiedItem, ISupportsPaging
	{
		/// <summary>
		///  Login name of the user
		/// </summary>
		[DataMember(Name = "UserName")]
		public string UserName { get; set; }

		/// <summary>
		///  First name of the user
		/// </summary>
		[DataMember(Name = "FirstName")]
		public string FirstName { get; set; }

		/// <summary>
		///  Last name of the user
		/// </summary>
		[DataMember(Name = "LastName")]
		public string LastName { get; set; }

		/// <summary>
		///  Email address of the user
		/// </summary>
		[DataMember(Name = "Email")]
		public string Email { get; set; }

		/// <summary>
		///  User employee ID
		/// </summary>
		[DataMember(Name = "EmployeeID")]
		public string EmployeeId { get; set; }

		/// <summary>
		///  User mobile phone number
		/// </summary>
		[DataMember(Name = "MobilePhone")]
		public string MobilePhone { get; set; }

		/// <summary>
		///  User access role (‘Accountants’, ‘Employees’, ‘Executives’, ‘Guests’, ‘Managers’)
		/// </summary>
		[DataMember(Name = "Role")]
		public string Role { get; set; }

		/// <summary>
		///  Indicates whether or not the user is a Treasurer (1 = yes, 0 = no)
		/// </summary>
		[DataMember(Name = "Treasurer")]
		public int Treasurer { get; set; }

		/// <summary>
		///  User has access to all settings in the Configuration tab (1 = yes, 0 = no)
		/// </summary>
		[DataMember(Name = "FullAdministrator")]
		public int FullAdministrator { get; set; }

		/// <summary>
		///  User has access to view/edit user profiles in the Configuration tab; cannot use the "Switch to this User" function (1 = yes, 0 = no)
		/// </summary>
		[DataMember(Name = "UserAdministrator")]
		public int UserAdministrator { get; set; }

		/// <summary>
		///  Department ID for the user
		/// </summary>
		[DataMember(Name = "DepartmentID")]
		public string DepartmentId { get; set; }

		/// <summary>
		///  Employee GLD1 ID for the user
		/// </summary>
		[DataMember(Name = "EmpGLD1ID")]
		public string EmpGLD1Id { get; set; }

		/// <summary>
		///  Employee GLD2 ID for the user
		/// </summary>
		[DataMember(Name = "EmpGLD2ID")]
		public string EmpGLD2Id { get; set; }

		/// <summary>
		///  Employee GLD3 ID for the user
		/// </summary>
		[DataMember(Name = "EmpGLD3ID")]
		public string EmpGLD3Id { get; set; }

		/// <summary>
		///  Employee GLD4 ID for the user
		/// </summary>
		[DataMember(Name = "EmpGLD4ID")]
		public string EmpGLD4Id { get; set; }

		/// <summary>
		///  Employee GLD5 ID for the user
		/// </summary>
		[DataMember(Name = "EmpGLD5ID")]
		public string EmpGLD5Id { get; set; }

		/// <summary>
		///  User culture ISO code (e.g.: ‘en-US')
		/// </summary>
		[DataMember(Name = "Culture")]
		public string Culture { get; set; }

		/// <summary>
		///  User two-character ISO language code (e.g.: ‘de’)
		/// </summary>
		[DataMember(Name = "Language")]
		public string Language { get; set; }

		/// <summary>
		///  	User three-character ISO currency code (e.g.: ‘USD’)
		/// </summary>
		[DataMember(Name = "Currency")]
		public string Currency { get; set; }

		/// <summary>
		///  	Date the user was last updated (YYYY-MM-DD)
		/// </summary>
		[DataMember(Name = "LastModifiedDate")]
		public string LastModifiedDate { get; set; }

		/// <summary>
		///  	The active status of the user (1 = active, 0 = inactive)
		/// </summary>
		[DataMember(Name = "Active")]
		public int Active { get; set; }
	}
}
