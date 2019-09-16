GET api/goals -- ����� ���� �����
GET api/goals/name/{Name} -- ����� ������ �� �� �����
GET api/goals/id/{Id} -- ����� ������ �� �� id

POST api/goals -- �������� ������
POST api/goals/upload/name/{Name} -- �������� ����� � ������ �� �� ����� � ���� IFormFie
POST api/goals/upload/id/{Id} -- �������� ����� � ������ �� �� id � ���� IFormFie

Delete api/goals/name/{Name} -- �������� ������ �� �����
Delete api/goals/id/{Id} -- �������� ������ �� id

PUT api/goals/name/{Name} -- ���������� ������ �� �����
PUT api/goals/id/{Id} -- ���������� ������ �� id

����������� ��� goal: 
{
	"Name" : "Task1",
	"Description" : "task1",
	"EndDate" : "2020-04-23T18:25:43.511Z",
	"CategoryId" : 2
}
���� goal: 
	public long TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Byte[] File { get; set; }
        public DateTime EndDate { get; set; }
        public long CategoryId { get; set; }
        public string Status { get; set; }

��������� 3 �� id: 1(High priority),2(Medium priority),3(low priority)
	
����� �������� � ����� ������� ��������� ���������: 
dotnet ef migrations add InitialCreate
dotnet ef database update
