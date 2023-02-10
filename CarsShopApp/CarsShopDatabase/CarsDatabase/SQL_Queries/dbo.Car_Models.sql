CREATE TABLE Car_Models (
    [Model_id]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [Model_name] NVARCHAR (200) NOT NULL,
    [Car_mark]   BIGINT         NOT NULL,
    PRIMARY KEY CLUSTERED ([Model_id] ASC),
	FOREIGN KEY (Car_mark) REFERENCES Car_Marks(Mark_id)
);

