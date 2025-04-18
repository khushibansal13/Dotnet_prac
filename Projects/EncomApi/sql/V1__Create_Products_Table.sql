CREATE TABLE Products (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Description VARCHAR(500),
    Price DECIMAL(18, 2) NOT NULL,
    DiscountPercentage DECIMAL(5, 2),
    Rating DECIMAL(3, 1),
    Stock INT NOT NULL,
    Tags JSON,
    Brand VARCHAR(100),
    Sku VARCHAR(50),
    Weight DECIMAL(10, 2),
    Dimensions JSON,
    WarrantyInformation VARCHAR(200),
    ShippingInformation VARCHAR(200),
    AvailabilityStatus VARCHAR(50),
    Reviews JSON,
    ReturnPolicy VARCHAR(100),
    MinimumOrderQuantity INT,
    Images JSON,
    Thumbnail VARCHAR(500),
    CategoryId INT
);