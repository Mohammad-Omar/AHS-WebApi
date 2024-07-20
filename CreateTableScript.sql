create table RoleType (
    RoleID int primary key,
    RoleDesc varchar(50) not null
);

create table Employee (
    EmployeeID int primary key,
    FirstName varchar(30),
    LastName varchar(30),
    [Address] varchar(100),
    RoleID int not null,
    foreign key (RoleID) references RoleType(RoleID)
);


create table Manager (
    EmployeeID int  primary key,
    AnnualSalary decimal(10, 2) not null,
    MaxExpenseAmount decimal(10, 2),
    foreign key (EmployeeID) references Employee(EmployeeID)
);


create table Supervisor (
    EmployeeID int  primary key,
    AnnualSalary decimal(10, 2) not null,
    foreign key (EmployeeID) references Employee(EmployeeID)
);


create table HourlyEmployee (
    EmployeeID int  primary key,
    PayPerHour decimal(5, 2) not null,
    foreign key (EmployeeID) references Employee(EmployeeID)
);
