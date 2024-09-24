USE LiteThinkingDemoDB;
GO

-- tasks table
CREATE TABLE tasks (
    task_id INT IDENTITY(100,1) PRIMARY KEY,
    task_title VARCHAR(50) NOT NULL,
    task_description VARCHAR(100),
    task_status VARCHAR(30) NOT NULL
);

INSERT INTO tasks VALUES ('Do LiteThinking challenge', '', 'In Progress');
INSERT INTO tasks VALUES ('Wash the dishes', '', 'Completed');
INSERT INTO tasks VALUES ('Go to the grocery store', '', 'Not Started');
INSERT INTO tasks VALUES ('Finish project timeline', '', 'Blocked');

-- create user to connect to Azure SQL
--create login demouser with password = 'demo$1234'
--create user demouser from login [demouser];
--create user demouser from login demouser;
--exec sp_addRoleMember 'db_owner', 'demouser';