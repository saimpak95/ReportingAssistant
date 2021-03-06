Create Database ReportingAssistantDB
go

use ReportingAssistantDB
go

create table Users(

UserID int primary key identity(1,1),
UserName nvarchar(100),
Email nvarchar(100),
PasswordHash nvarchar(100),
Role nvarchar(100) default 'User',
Phone nvarchar(100),
Gender nvarchar(50)

)
go


select * from Users
create table Categories(

CategoryID int primary key identity(1,1),
CategoryName nvarchar(100) unique not null

)
go

create table Projects(

ProjectID int primary key identity(1,1),
ProjectName nvarchar(100) unique not null ,
DateOfStart datetime,
AvailabilityStatus nvarchar(100),
CategoryID int references Categories(CategoryID) on delete cascade,
Attachments nvarchar(max) null,
AdminID int references Users(UserID)
)
go
select * from Projects
create table Tasks(

TaskID int primary key identity(1,1),
Screen nvarchar(100),
TaskDescription nvarchar(max),
AdminID int references Users(UserID),
UserID int references Users(UserID),
DateOfTask datetime,
Attachments nvarchar(max) null,
ProjectID int references Projects(ProjectID)
)
go

create table TasksDone(

TaskDoneID int primary key identity(1,1),
Screen nvarchar(100),
TaskDoneDescription nvarchar(max),
UserID int references Users(UserID) on delete set null,
DateOfTaskDone datetime,
Attachments nvarchar(max) null,
TaskID int references Tasks(TaskID) on delete set null
)
go

create table FinalComments(

FinalCommentID int primary key identity(1,1),
Screen nvarchar(100),
FinalCommentDescription nvarchar(max),
UserID int references Users(UserID) on delete set null,
DateOfFinalComment datetime,
Attachments nvarchar(max) null,
ProjectID int references Projects(ProjectID) on delete set null

)
go


