create table BusinessObject(
    Id int identity (1,1) primary key,
    Stub varchar(30),
    Description varchar (255),
    Active bit default 1
);
create table BusinessObjectType(
    Id int identity (1,1) primary key,
    BusinessObject int references BusinessObject(id) not null,
    Stub varchar(30),
    Description varchar (255),
    Active bit default 1
);
create table MaintenanceTemplate(
    Id int identity (1,1) primary key,
    Stub varchar(30),
    Description varchar (255),
    ScheduleType int references BusinessObjectType(id) not null,
    WorkOrderType int references BusinessObjectType(id) not null,
    Duration int, -- length in days
    Active bit default 1
);


insert into BusinessObject (stub, description) values ('WorkOrder', 'WorkOrder Business Object');
insert into BusinessObject (stub, description) values ('MaintenanceTemplate', 'WorkOrder Business Object');

insert into BusinessObjectType (BusinessObject, Stub, Description) values (1, 'WorkType1', 'Type1 Description' );
insert into BusinessObjectType (BusinessObject, Stub, Description) values (1, 'WorkType2', 'Type1 Description' );
insert into BusinessObjectType (BusinessObject, Stub, Description) values (1, 'WorkType3', 'Type1 Description' );

insert into BusinessObjectType (BusinessObject, Stub, Description) values (2, 'MaintenanceTemplate1', 'Type1 Description' );
insert into BusinessObjectType (BusinessObject, Stub, Description) values (2, 'MaintenanceTemplate2', 'Type2 Description' );
insert into BusinessObjectType (BusinessObject, Stub, Description) values (2, 'MaintenanceTemplate3', 'Type3 Description' );