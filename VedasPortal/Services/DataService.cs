using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VedasPortal.Services
{
	public partial class DataRecord
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime Birthday { get; set; }
		public string PetName { get; set; }
		public string Country { get; set; }
		public string ProductName { get; set; }
		public double Price { get; set; }
		public int Quantity { get; set; }
		public DateTime TimeOfPurchase { get; set; }
		public bool Expired { get; set; }
		public string Email { get; set; }
		public string Url { get; set; }
		public string Attachments { get; set; }
		public double Total { get; set; }
	}
	public partial class KanbanDataRecord
	{
		[JsonPropertyName("status")]
		public string Status
		{
			get;
			set;
		}

		[JsonPropertyName("color")]
		public string Color
		{
			get;
			set;
		}

		[JsonPropertyName("priority")]
		public string Priority
		{
			get;
			set;
		}

		[JsonPropertyName("text")]
		public string Text
		{
			get;
			set;
		}
		[JsonPropertyName("tags")]
		public string Tags
		{
			get;
			set;
		}

		[JsonPropertyName("progress")]
		public int Progress
		{
			get;
			set;
		}

		[JsonPropertyName("userId")]
		public int UserId
		{
			get;
			set;
		}

		[JsonPropertyName("id")]
		public int Id
		{
			get;
			set;
		}

		[JsonPropertyName("checkList")]
		public object[] CheckList
		{
			get;
			set;
		}

		[JsonPropertyName("comments")]
		public object[] Comments
		{
			get;
			set;
		}

		[JsonPropertyName("startDate")]
		public DateTime StartDate
		{
			get;
			set;
		}

		[JsonPropertyName("dueDate")]
		public DateTime DueDate
		{
			get;
			set;
		}

	}
	public partial class GanttDataRecord
	{
		[JsonPropertyName("id")]
		public string Id
		{
			get;
			set;
		}

		[JsonPropertyName("label")]
		public string Label
		{
			get;
			set;
		}
		[JsonPropertyName("dateStart")]
		public string DateStart
		{
			get; set;
		}

		[JsonPropertyName("dateEnd")]
		public string DateEnd
		{
			get; set;
		}

		[JsonPropertyName("class")]
		public string Class
		{
			get; set;
		}

		[JsonPropertyName("type")]
		public string Type
		{
			get; set;
		}

		[JsonPropertyName("progress")]
		public int Progress
		{
			get; set;
		}

		[JsonPropertyName("duration")]
		public int Duration
		{
			get; set;
		}

		[JsonPropertyName("synchronized")]
		public bool Synchronized
		{
			get; set;
		}

		[JsonPropertyName("expanded")]
		public bool Expanded
		{
			get; set;
		}

		[JsonPropertyName("tasks")]
		public List<GanttDataRecord> Tasks
		{
			get; set;
		}

		[JsonPropertyName("disableResources")]
		public bool DisableResources
		{
			get; set;
		}

		[JsonPropertyName("resources")]
		public object Resources
		{
			get; set;
		} = new object[] { };

		[JsonPropertyName("connections")]
		public List<Dictionary<string, int>> Connections
		{
			get; set;
		} = new List<Dictionary<string, int>>() { };

		[JsonPropertyName("disableDrag")]
		public bool DisableDrag
		{
			get; set;
		}

		[JsonPropertyName("disableResize")]
		public bool DisableResize
		{
			get; set;
		}

		[JsonPropertyName("minDateStart")]
		public string MinDateStart
		{
			get; set;
		}

		[JsonPropertyName("maxDateStart")]
		public string MaxDateStart
		{
			get; set;
		}

		[JsonPropertyName("minDateEnd")]
		public string MinDateEnd
		{
			get; set;
		}

		[JsonPropertyName("maxDateEnd")]
		public string MaxDateEnd
		{
			get; set;
		}

		[JsonPropertyName("minDuration")]
		public int MinDuration
		{
			get; set;
		}

		[JsonPropertyName("maxDuration")]
		public int MaxDuration
		{
			get; set;
		}

		[JsonPropertyName("value")]
		public int Value
		{
			get; set;
		}

		[JsonPropertyName("dragProject")]
		public bool DragProject
		{
			get; set;
		}
	}

	

	public class SchedulerDataRecord
	{
		public DateTime DateStart { get; set; }
		public DateTime DateEnd { get; set; }
		public string Label { get; set; }
		public bool AllDay { get; set; }
		public string BackgroundColor { get; set; }

	}
	public class RandomDataService
	{
		public List<SchedulerDataRecord> GenerateSchedulerData()
		{
			List<SchedulerDataRecord> dataSource = new List<SchedulerDataRecord>()
			{
				 new SchedulerDataRecord() {
					Label = "Google AdWords Strategy",
					DateStart = new DateTime(2021, 1, 10, 9, 0, 0),
					DateEnd = new DateTime(2021, 1, 11, 10, 30, 0),
					AllDay = true,
					BackgroundColor = "#EA80FC"
				}, new SchedulerDataRecord() {
					Label = "New Brochures",
					DateStart = new DateTime(2021, 1, 11, 11, 30, 0),
					DateEnd = new DateTime(2021, 1, 12, 14, 15, 0),
					BackgroundColor = "#FF9E80"
				}, new SchedulerDataRecord() {
					Label = "Brochure Design Review",
					DateStart = new DateTime(2021, 1, 12, 13, 15, 0),
					DateEnd = new DateTime(2021, 1, 14, 16, 15, 0),
					BackgroundColor = "#039BE5"
				}, new SchedulerDataRecord() {
					Label = "Website Re-Design Plan",
					DateStart = new DateTime(2021, 1, 16, 16, 45, 0),
					DateEnd = new DateTime(2021, 1, 20, 11, 15, 0),
					BackgroundColor = "#78909C"
				},
				new SchedulerDataRecord() {
					Label = "Rollout of New Website and Marketing Brochures",
					DateStart = new DateTime(2021, 1, 2, 8, 15, 0),
					DateEnd = new DateTime(2021, 1, 2, 10, 45, 0),
					BackgroundColor = "#D500F9"
				}, new SchedulerDataRecord() {
					Label = "UpDateTime Sales Strategy Documents",
					DateStart = new DateTime(2021, 1, 2, 12, 0, 0),
					DateEnd = new DateTime(2021, 1, 2, 13, 45, 0),
					BackgroundColor = "#689F38"
				}, new SchedulerDataRecord() {
					Label = "Non-Compete Agreements",
					DateStart = new DateTime(2021, 1, 3, 8, 15, 0),
					DateEnd = new DateTime(2021, 1, 3, 9, 0, 0),
					BackgroundColor = "#9CCC65"
				}, new SchedulerDataRecord() {
					Label = "Approve Hiring of John Jeffers",
					DateStart = new DateTime(2021, 1, 3, 10, 0, 0),
					DateEnd = new DateTime(2021, 1, 3, 11, 15, 0),
					BackgroundColor = "#EF6C00"
				}, new SchedulerDataRecord() {
					Label = "UpDateTime NDA Agreement",
					DateStart = new DateTime(2021, 1, 3, 11, 45, 0),
					DateEnd = new DateTime(2021, 1, 3, 13, 45, 0),
					BackgroundColor = "#009688"
				}, new SchedulerDataRecord() {
					Label = "UpDateTime Employee Files with New NDA",
					DateStart = new DateTime(2021, 1, 3, 14, 0, 0),
					DateEnd = new DateTime(2021, 1, 3, 16, 45, 0),
					BackgroundColor = "#FF1744"
				}, new SchedulerDataRecord() {
					Label = "Submit Questions Regarding New NDA",
					DateStart = new DateTime(2021, 1, 6, 8, 0, 0),
					DateEnd = new DateTime(2021, 1, 6, 9, 30, 0),
					BackgroundColor = "#689F38"
				}, new SchedulerDataRecord() {
					Label = "Submit Signed NDA",
					DateStart = new DateTime(2021, 1, 6, 12, 45, 0),
					DateEnd = new DateTime(2021, 1, 6, 14, 0, 0),
					BackgroundColor = "#76FF03"
				}, new SchedulerDataRecord() {
					Label = "Review Revenue Projections",
					DateStart = new DateTime(2021, 1, 6, 17, 15, 0),
					DateEnd = new DateTime(2021, 1, 6, 18, 0, 0),
					BackgroundColor = "#F9A825"
				}, new SchedulerDataRecord() {
					Label = "Comment on Revenue Projections",
					DateStart = new DateTime(2021, 1, 5, 9, 15, 0),
					DateEnd = new DateTime(2021, 1, 5, 11, 15, 0),
					BackgroundColor = "#2962FF"
				}, new SchedulerDataRecord() {
					Label = "Provide New Health Insurance Docs",
					DateStart = new DateTime(2021, 1, 5, 12, 45, 0),
					DateEnd = new DateTime(2021, 1, 5, 14, 15, 0),
					BackgroundColor = "#FF6E40"
				}, new SchedulerDataRecord() {
					Label = "Review Changes to Health Insurance Coverage",
					DateStart = new DateTime(2021, 1, 5, 14, 15, 0),
					DateEnd = new DateTime(2021, 1, 5, 15, 30, 0),
					BackgroundColor = "#F06292"
				}, new SchedulerDataRecord() {
					Label = "Review Training Course for any Ommissions",
					DateStart = new DateTime(2021, 1, 8, 14, 0, 0),
					DateEnd = new DateTime(2021, 1, 9, 12, 0, 0),
					BackgroundColor = "#689F38"
				}, new SchedulerDataRecord() {
					Label = "Recall Rebate Form",
					DateStart = new DateTime(2021, 1, 8, 12, 45, 0),
					DateEnd = new DateTime(2021, 1, 8, 13, 15, 0),
					BackgroundColor = "#4A148C"
				}, new SchedulerDataRecord() {
					Label = "Create Report on Customer Feedback",
					DateStart = new DateTime(2021, 1, 9, 15, 15, 0),
					DateEnd = new DateTime(2021, 1, 9, 17, 30, 0),
					BackgroundColor = "#A1887F"
				}, new SchedulerDataRecord() {
					Label = "Review Customer Feedback Report",
					DateStart = new DateTime(2021, 1, 9, 16, 15, 0),
					DateEnd = new DateTime(2021, 1, 9, 18, 30, 0),
					BackgroundColor = "#BA68C8"
				}, new SchedulerDataRecord() {
					Label = "Customer Feedback Report Analysis",
					DateStart = new DateTime(2021, 1, 10, 9, 30, 0),
					DateEnd = new DateTime(2021, 1, 10, 10, 30, 0),
					BackgroundColor = "#C51162"
				}, new SchedulerDataRecord() {
					Label = "Prepare Shipping Cost Analysis Report",
					DateStart = new DateTime(2021, 1, 10, 12, 30, 0),
					DateEnd = new DateTime(2021, 1, 10, 13, 30, 0),
					BackgroundColor = "#0277BD"
				}, new SchedulerDataRecord() {
					Label = "Provide Feedback on Shippers",
					DateStart = new DateTime(2021, 1, 10, 14, 15, 0),
					DateEnd = new DateTime(2021, 1, 10, 16, 0, 0),
					BackgroundColor = "#8E24AA"
				}, new SchedulerDataRecord() {
					Label = "Select Preferred Shipper",
					DateStart = new DateTime(2021, 1, 10, 17, 30, 0),
					DateEnd = new DateTime(2021, 1, 10, 20, 0, 0),
					BackgroundColor = "#689F38"
				}, new SchedulerDataRecord() {
					Label = "Complete Shipper Selection Form",
					DateStart = new DateTime(2021, 1, 11, 8, 30, 0),
					DateEnd = new DateTime(2021, 1, 11, 10, 0, 0),
					BackgroundColor = "#388E3C"
				}, new SchedulerDataRecord() {
					Label = "Upgrade Server Hardware",
					DateStart = new DateTime(2021, 1, 11, 12, 0, 0),
					DateEnd = new DateTime(2021, 1, 11, 14, 15, 0),
					BackgroundColor = "#00C853"
				}, new SchedulerDataRecord() {
					Label = "Upgrade Personal Computers",
					DateStart = new DateTime(2021, 1, 11, 14, 45, 0),
					DateEnd = new DateTime(2021, 1, 11, 16, 30, 0),
					BackgroundColor = "#6200EA"
				}, new SchedulerDataRecord() {
					Label = "Upgrade Apps to Windows RT or stay with WinForms",
					DateStart = new DateTime(2021, 1, 12, 10, 30, 0),
					DateEnd = new DateTime(2021, 1, 12, 13, 0, 0),
					BackgroundColor = "#66BB6A"
				}, new SchedulerDataRecord() {
					Label = "Estimate Time Required to Touch-Enable Apps",
					DateStart = new DateTime(2021, 1, 12, 14, 45, 0),
					DateEnd = new DateTime(2021, 1, 12, 16, 30, 0),
					BackgroundColor = "#795548"
				}, new SchedulerDataRecord() {
					Label = "Report on Tranistion to Touch-Based Apps",
					DateStart = new DateTime(2021, 1, 12, 18, 30, 0),
					DateEnd = new DateTime(2021, 1, 12, 19, 0, 0),
					BackgroundColor = "#FBC02D"
				}, new SchedulerDataRecord() {
					Label = "Submit New Website Design",
					DateStart = new DateTime(2021, 1, 15, 8, 0, 0),
					DateEnd = new DateTime(2021, 1, 15, 10, 0, 0),
					BackgroundColor = "#26A69A"
				}, new SchedulerDataRecord() {
					Label = "Create Icons for Website",
					DateStart = new DateTime(2021, 1, 15, 11, 30, 0),
					DateEnd = new DateTime(2021, 1, 15, 13, 15, 0),
					BackgroundColor = "#4DB6AC"
				}, new SchedulerDataRecord() {
					Label = "Create New Product Pages",
					DateStart = new DateTime(2021, 1, 16, 9, 45, 0),
					DateEnd = new DateTime(2021, 1, 16, 11, 45, 0),
					BackgroundColor = "#FDD835"
				}, new SchedulerDataRecord() {
					Label = "Approve Website Launch",
					DateStart = new DateTime(2021, 1, 16, 12, 0, 0),
					DateEnd = new DateTime(2021, 1, 16, 15, 15, 0),
					BackgroundColor = "#FF6E40"
				}, new SchedulerDataRecord() {
					Label = "UpDateTime Customer Shipping Profiles",
					DateStart = new DateTime(2021, 1, 17, 9, 30, 0),
					DateEnd = new DateTime(2021, 1, 17, 11, 0, 0),
					BackgroundColor = "#388E3C"
				}, new SchedulerDataRecord() {
					Label = "Create New Shipping Return Labels",
					DateStart = new DateTime(2021, 1, 17, 12, 45, 0),
					DateEnd = new DateTime(2021, 1, 17, 14, 0, 0),
					BackgroundColor = "#3E2723"
				}, new SchedulerDataRecord() {
					Label = "Get Design for Shipping Return Labels",
					DateStart = new DateTime(2021, 1, 17, 15, 0, 0),
					DateEnd = new DateTime(2021, 1, 17, 16, 30, 0),
					BackgroundColor = "#AEEA00"
				}, new SchedulerDataRecord() {
					Label = "PSD needed for Shipping Return Labels",
					DateStart = new DateTime(2021, 1, 18, 8, 30, 0),
					DateEnd = new DateTime(2021, 1, 18, 9, 15, 0),
					BackgroundColor = "#FF80AB"
				}, new SchedulerDataRecord() {
					Label = "Contact ISP and Discuss Payment Options",
					DateStart = new DateTime(2021, 1, 18, 11, 30, 0),
					DateEnd = new DateTime(2021, 1, 18, 16, 0, 0),
					BackgroundColor = "#26C6DA"
				}, new SchedulerDataRecord() {
					Label = "Prepare Year-End Support Summary Report",
					DateStart = new DateTime(2021, 1, 18, 17, 0, 0),
					DateEnd = new DateTime(2021, 1, 18, 20, 0, 0),
					BackgroundColor = "#E57373"
				}, new SchedulerDataRecord() {
					Label = "Review New Training Material",
					DateStart = new DateTime(2021, 1, 19, 8, 0, 0),
					DateEnd = new DateTime(2021, 1, 19, 9, 15, 0),
					BackgroundColor = "#40C4FF"
				}, new SchedulerDataRecord() {
					Label = "Distribute Training Material to Support Staff",
					DateStart = new DateTime(2021, 1, 19, 12, 45, 0),
					DateEnd = new DateTime(2021, 1, 19, 14, 0, 0),
					BackgroundColor = "#6D4C41"
				}, new SchedulerDataRecord() {
					Label = "Training Material Distribution Schedule",
					DateStart = new DateTime(2021, 1, 19, 14, 15, 0),
					DateEnd = new DateTime(2021, 1, 19, 16, 15, 0),
					BackgroundColor = "#60BF96"
				}, new SchedulerDataRecord() {
					Label = "Approval on Converting to New HDMI Specification",
					DateStart = new DateTime(2021, 1, 22, 9, 30, 0),
					DateEnd = new DateTime(2021, 1, 22, 10, 15, 0),
					BackgroundColor = "#689F38"
				}, new SchedulerDataRecord() {
					Label = "Create New Spike for Automation Server",
					DateStart = new DateTime(2021, 1, 22, 10, 0, 0),
					DateEnd = new DateTime(2021, 1, 22, 12, 30, 0),
					BackgroundColor = "#BFA300"
				}, new SchedulerDataRecord() {
					Label = "Code Review - New Automation Server",
					DateStart = new DateTime(2021, 1, 22, 13, 0, 0),
					DateEnd = new DateTime(2021, 1, 22, 15, 0, 0),
					BackgroundColor = "#0095FF"
				}, new SchedulerDataRecord() {
					Label = "Confirm Availability for Sales Meeting",
					DateStart = new DateTime(2021, 1, 23, 10, 15, 0),
					DateEnd = new DateTime(2021, 1, 23, 15, 15, 0),
					BackgroundColor = "#B6B6B6"
				}, new SchedulerDataRecord() {
					Label = "Reschedule Sales Team Meeting",
					DateStart = new DateTime(2021, 1, 23, 16, 15, 0),
					DateEnd = new DateTime(2021, 1, 23, 18, 0, 0),
					BackgroundColor = "#800037"
				}, new SchedulerDataRecord() {
					Label = "Send 2 Remotes for Giveaways",
					DateStart = new DateTime(2021, 1, 24, 9, 30, 0),
					DateEnd = new DateTime(2021, 1, 24, 11, 45, 0),
					BackgroundColor = "#BF6060"
				}, new SchedulerDataRecord() {
					Label = "Discuss Product Giveaways with Management",
					DateStart = new DateTime(2021, 1, 24, 12, 15, 0),
					DateEnd = new DateTime(2021, 1, 24, 16, 45, 0),
					BackgroundColor = "#BF60B2"
				}, new SchedulerDataRecord() {
					Label = "Replace Desktops on the 3rd Floor",
					DateStart = new DateTime(2021, 1, 25, 9, 30, 0),
					DateEnd = new DateTime(2021, 1, 25, 10, 45, 0),
					BackgroundColor = "#BFB160"
				}, new SchedulerDataRecord() {
					Label = "UpDateTime Database with New Leads",
					DateStart = new DateTime(2021, 1, 25, 12, 0, 0),
					DateEnd = new DateTime(2021, 1, 25, 14, 15, 0),
					BackgroundColor = "#BF0000"
				}, new SchedulerDataRecord() {
					Label = "Mail New Leads for Follow Up",
					DateStart = new DateTime(2021, 1, 25, 14, 45, 0),
					DateEnd = new DateTime(2021, 1, 25, 15, 30, 0),
					BackgroundColor = "#7B60BF"
				}, new SchedulerDataRecord() {
					Label = "Send Territory Sales Breakdown",
					DateStart = new DateTime(2021, 1, 25, 18, 0, 0),
					DateEnd = new DateTime(2021, 1, 25, 20, 0, 0),
					BackgroundColor = "#39BF00"
				}, new SchedulerDataRecord() {
					Label = "Territory Sales Breakdown Report",
					DateStart = new DateTime(2021, 1, 26, 8, 45, 0),
					DateEnd = new DateTime(2021, 1, 26, 9, 45, 0),
					BackgroundColor = "#403600"
				}, new SchedulerDataRecord() {
					Label = "Report on the State of Engineering Dept",
					DateStart = new DateTime(2021, 1, 26, 14, 45, 0),
					DateEnd = new DateTime(2021, 1, 26, 15, 30, 0),
					BackgroundColor = "#3D8020"
				},
					new SchedulerDataRecord() {
					Label = "Staff Productivity Report",
					DateStart = new DateTime(2021, 1, 26, 16, 15, 0),
					DateEnd = new DateTime(2021, 1, 26, 19, 30, 0),
					BackgroundColor = "#BF60B2"
				}
			};

			return dataSource;
		}

		public List<KanbanDataRecord> GenerateKanbanData()
		{
			string[] text = new string[]{
				"Research", "Displaying data from data source", "Showing cover and title", "Property validation",
				"formatFunction and formatSettings", "Expand/collapse arrow", "Virtual scrolling", "Deferred scrolling",
				"Infinite scrolling", "Visible/hidden columns", "Public methods", "Editing",
				"Header", "Dragging with feedback", "Vertical virtualization", "Observable columns array",
				"Reusing existing HTML elements", "Virtualize collapsed cards"
		};

			string[] tags = new string[] { "initial", "data", "visual", "property", "scrolling", "method" };

			List<KanbanDataRecord> data = new List<KanbanDataRecord>{
			new KanbanDataRecord(){
				Id= 0,
				Status= "Done",
				Text= text[0],
				Tags= tags[0],
				Progress= 100,
				UserId= 2
			},
			new KanbanDataRecord(){
				Id= 1,
				Status= "Done",
				Text= text[1],
				Tags= tags[1],
				Priority= "High",
				Progress= 100,
				UserId= 3
			},
			new KanbanDataRecord(){
				Id= 2,
				Status= "Done",
				Text= text[2],
				Tags= tags[2] + ", " + tags[3],
				Priority= "High",
				Progress= 100,
				UserId= 2
			},
			new KanbanDataRecord(){
				Id= 3,
				Status= "Done",
				Text= text[3],
				Tags= tags[3],
				CheckList= new object[]
				{
					new { Text= "addNewButton", Completed= true },
					new { Text= "allowDrag", Completed= true },
					new { Text= "cardHeight", Completed= true },
					new { Text= "cellOrientation", Completed= true },
					new { Text= "collapsible", Completed= true },
					new { Text= "columns", Completed= true }
				},
				UserId= 1
			},
			new KanbanDataRecord(){
				Id= 4,
				Status= "Done",
				Text= text[4],
				Tags= tags[1] + ", " + tags[3],
				Progress= 100,
				UserId= 0
			},
			new KanbanDataRecord(){
				 Id= 5,
				Status= "Testing",
				Text= text[5],
				Tags= tags[2],
				Progress= 90,
				UserId= 3
			},
			new KanbanDataRecord(){
				Id= 7,
				Status= "Testing",
				Text= text[6],
				Tags= tags[4] + ", " + tags[1],
				Progress= 10,
				UserId= 3
			},
			new KanbanDataRecord(){
				Id= 6,
				Status= "Testing",
				Text= text[7],
				Tags= tags[4],
				Color= "#9966CC",
				UserId= 3
			},
			new KanbanDataRecord(){
				Id= 8,
				Status= "InProgress",
				Text= text[8],
				Tags= tags[4] + ", " + tags[1],
				Progress= 25,
				UserId= 0
			},
			new KanbanDataRecord(){
				Id= 9,
				Status= "InProgress",
				Text= text[9],
				Tags= tags[2],
				Priority= "High",
				Progress= 85,
				Color= "red",
				UserId= 1
			},
			new KanbanDataRecord(){
				Id= 10,
				Status= "InProgress",
				Text= text[10],
				Tags= tags[5],
				CheckList= new object[]
				{
					new { Text= "closePanel", Completed= true },
					new { Text= "openCustomizePanel", Completed= true },
					new { Text= "openFilterPanel", Completed= true },
					new { Text= "openSortPanel", Completed= false },
					new { Text= "showColumn", Completed= false },
					new { Text= "hideColumn", Completed= false },
					new { Text= "addFilter", Completed= false },
					new { Text= "removeFilter", Completed= false }
				},
				UserId= 2
			},
			new KanbanDataRecord(){
				Id= 11,
				Status= "ToDo",
				Text= text[11],
				Tags= tags[5],
				Priority= "High",
				Progress= 0
			},
			new KanbanDataRecord(){
				Id= 12,
				Status= "ToDo",
				Text= text[12],
				Tags= tags[2]
			},
			new KanbanDataRecord(){
				Id= 13,
				Status= "ToDo",
				Text= text[13],
				Tags= tags[2] + ", " + tags[5] + ", " + tags[1],
				Priority= "low",
				UserId= 4
			},
			new KanbanDataRecord(){
				Id= 14,
				Status= "ToDo",
				Text= text[14],
				CheckList= new object[] {
					new { Text= text[16], Completed= false },
					new { Text= text[17], Completed= false }
				},
				UserId= 1
			},
			new KanbanDataRecord(){
				Id= 15,
				Status= "ToDo",
				Text= text[15],
				Tags= tags[1]
			}
		};

			string[] comments = new string[]{
				"Ut ultrices dolor vitae magna lacinia vehicula.",
				"Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
				"Donec vitae dapibus mauris, quis cursus nibh.",
				"Aenean ultrices maximus ex id scelerisque. Suspendisse cursus maximus nulla, sed ornare lectus aliquet eu. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
				"Curabitur at accumsan metus, rhoncus porttitor ligula.",
				"Nulla sodales faucibus accumsan."
			};

			for (int i = 0; i < data.Count; i++)
			{
				KanbanDataRecord task = data[i];

				DateTime startDate = new DateTime(2020, 1 + new Random().Next(10), 1 + new Random().Next(25));

				task.StartDate = startDate;


				if (task.Priority == "High" && task.Status != "Done")
				{
					task.DueDate = new DateTime(2020, startDate.Month, task.StartDate.Day + 1);
				}
				else if (task.Priority == "Low")
				{
					task.DueDate = new DateTime(2020, startDate.Month, task.StartDate.Day + 1);
				}
				else
				{
					task.DueDate = new DateTime(2020, startDate.Month, task.StartDate.Day + 1);
				}


				int numberOfComments = new Random().Next(3);

				task.Comments = new object[] { };
				List<object> taskComments = new List<object>();

				for (int j = 0; j < numberOfComments; j++)
				{
					taskComments.Add(new
					{
						text = comments[new Random().Next(5)],
						userId = new Random().Next(4),
						time = new DateTime()
					});

					task.Comments = taskComments.ToArray();
				}
			}

			return data;
		}

		public List<KanbanDataRecord> GenerateKanbanHierarchicalData()
		{
			List<KanbanDataRecord> data = new List<KanbanDataRecord>{
				new KanbanDataRecord()
				{
					Id = 16,
					Status = "Desktop",
					Text = "Customize cards panel",
					Tags = "visual, data",
					Progress = 50,
					UserId = 3
				},
				new KanbanDataRecord()
				{
					Id = 17,
					Status = "Desktop",
					Text = "Filter panel",
					Tags = "visual, data",
					Priority = "high",
					Progress = 90,
					UserId = 1
				},
				new KanbanDataRecord()
				{
					Id = 18,
					Status = "Mobile",
					Text = "Sort panel",
					Tags = "visual, data",
					Priority = "high",
					Progress = 15,
					UserId = 2
				},
				new KanbanDataRecord()
				{
					Id = 19,
					Status = "ManualTesting",
					Text = "Search bar",
					Tags = "visual, data",
					Progress = 20,
					UserId = 4

				},
				new KanbanDataRecord()
				{
					Id = 20,
					Status = "UnitTesting",
					Text = "Cancel and Save buttons",
					Tags = "visual, data",
					Progress = 90,
					UserId = 0

				},
				new KanbanDataRecord()
				{
					Id = 21,
					Status = "UnitTesting",
					Text = "Dynamically show/hide column",
					Tags = "visual",
					Progress = 60,
					UserId = 3
				},
				new KanbanDataRecord()
				{
					Id = 22,
					Status = "UnitTesting",
					Text = "Property changed handlers",
					Tags = "property",
					Progress = 10,
					UserId = 3
				}
			};

			return data.Concat(GenerateKanbanData()).ToList();
		}

		

		public List<Dictionary<string, double>> GenerateNumbersData()
		{
			Random random = new Random();

			List<Dictionary<string, double>> data = new List<Dictionary<string, double>>();
			for (int i = 0; i < 20; i++)
			{
				Dictionary<string, double> row = new Dictionary<string, double>()
				{
					{ "A", Math.Round(random.NextDouble(), 2) },
					{ "B", Math.Round(random.NextDouble(), 2) },
					{ "C", Math.Round(random.NextDouble(), 2) },
					{ "D", Math.Round(random.NextDouble(), 2) },
					{ "E", Math.Round(random.NextDouble(), 2) },
					{ "F", Math.Round(random.NextDouble(), 2) },
					{ "G", Math.Round(random.NextDouble(), 2) },
					{ "H", Math.Round(random.NextDouble(), 2) },
					{ "I", Math.Round(random.NextDouble(), 2) },
					{ "J", Math.Round(random.NextDouble(), 2) }
				};

				data.Add(row);
			}

			return data;
		}

		public List<GanttDataRecord> GenerateGanttData()
		{
			List<GanttDataRecord> records = new List<GanttDataRecord>()
			{
				new GanttDataRecord() {
					Label= "PRD & User-Stories",
					DateStart= "2021-01-10",
					DateEnd= "2021-03-10",
					Class= "product-team",
					Type= "task"
				},
				new GanttDataRecord() {
					Label= "Persona & Journey",
					DateStart= "2021-03-01",
					DateEnd= "2021-04-30",
					Class= "marketing-team",
					Type= "task"
				},
				new GanttDataRecord() {
					Label= "Architecture",
					DateStart= "2021-04-11",
					DateEnd= "2021-05-16",
					Class= "product-team",
					Type= "task"
				},
				new GanttDataRecord() {
					Label= "Prototyping",
					DateStart= "2021-05-17",
					DateEnd= "2021-07-01",
					Class= "dev-team",
					Type= "task"
				},
				new GanttDataRecord() {
					Label= "Design",
					DateStart= "2021-07-02",
					DateEnd= "2021-08-01",
					Class= "design-team",
					Type= "task"
				},
				new GanttDataRecord() {
					Label= "Development",
					DateStart= "2021-08-01",
					DateEnd= "2021-09-10",
					Class= "dev-team",
					Type= "task"
				},
				new GanttDataRecord() {
					Label= "Testing & QA",
					DateStart= "2021-09-11",
					DateEnd= "2021-10-10",
					Class= "qa-team",
					Type= "task"
				},
				new GanttDataRecord() {
					Label= "UAT Test",
					DateStart= "2021-10-12",
					DateEnd= "2021-11-11",
					Class= "product-team",
					Type= "task"
				},
				new GanttDataRecord() {
					Label= "Handover & Documentation",
					DateStart= "2021-10-17",
					DateEnd= "2021-11-31",
					Class= "marketing-team",
					Type= "task"
				},
				new GanttDataRecord() {
					Label= "Release",
					DateStart= "2021-11-01",
					DateEnd= "2021-12-31",
					Class= "release-team",
					Type= "task"
				}
			};

			return records;
		}

		public Task<GanttDataRecord[]> GetGanttDataAsync()
		{
			List<GanttDataRecord> records = GenerateGanttData();

			return Task.FromResult(records.ToArray());
		}

		public Task<KanbanDataRecord[]> GetKanbanDataAsync()
		{
			List<KanbanDataRecord> records = GenerateKanbanData();

			return Task.FromResult(records.ToArray());
		}
	}
}
