CREATE TABLE Cars (
    [Car_id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [Car_name]               NVARCHAR (100) NOT NULL,
    [Car_mark]               BIGINT         NOT NULL,
    [Car_model]              BIGINT         NOT NULL,
    [Car_manufacturing_date] NVARCHAR (100) NOT NULL,
    [Car_fuel]               BIGINT			NOT NULL,
    [Car_engine_volume]      INT            NULL,
    [Car_gearbox]            BIGINT         NOT NULL,
    [Car_type]				 BIGINT			NOT NULL, 
    PRIMARY KEY CLUSTERED ([Car_id] ASC),
	FOREIGN KEY (Car_mark) REFERENCES Car_Marks(Mark_id),
	FOREIGN KEY (Car_model) REFERENCES Car_Models(Model_id),
	FOREIGN KEY (Car_fuel) REFERENCES Fuels(Fuel_id),
	FOREIGN KEY (Car_gearbox) REFERENCES Car_Gearboxes(Gearbox_id),
	FOREIGN KEY (Car_type) REFERENCES Car_Types(Type_id)
);

