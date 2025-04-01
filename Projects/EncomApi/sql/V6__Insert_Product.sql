INSERT INTO Products (
    Title, Description, Price, DiscountPercentage, Rating, Stock, Tags, Brand, Sku, Weight,
    Dimensions, WarrantyInformation, ShippingInformation, AvailabilityStatus, Reviews,
    ReturnPolicy, MinimumOrderQuantity, Images, Thumbnail, CategoryId
) VALUES
    (
        '300 Touring',
        'The 300 Touring is a stylish and comfortable sedan, known for its luxurious features and smooth performance.',
        28999.99,
        7.15,
        4.6,
        53,
        '["sedans", "vehicles"]',
        'Chrysler',
        'SPG50KEL',
        5.00,
        '{"width": 5.03, "height": 6.98, "depth": 8.65}',
        '3 year warranty',
        'Ships overnight',
        'In Stock',
        '[
            {"rating": 2, "comment": "Would not recommend!", "date": "2024-05-23T08:56:21.626Z", "reviewerName": "Miles Stevenson", "reviewerEmail": "miles.stevenson@x.dummyjson.com"},
            {"rating": 5, "comment": "Very happy with my purchase!", "date": "2024-05-23T08:56:21.626Z", "reviewerName": "Hannah Robinson", "reviewerEmail": "hannah.robinson@x.dummyjson.com"},
            {"rating": 5, "comment": "Great value for money!", "date": "2024-05-23T08:56:21.626Z", "reviewerName": "Harper Turner", "reviewerEmail": "harper.turner@x.dummyjson.com"}
        ]',
        'No return policy',
        1,
        '[
            "https://cdn.dummyjson.com/products/images/vehicle/300%20Touring/1.png",
            "https://cdn.dummyjson.com/products/images/vehicle/300%20Touring/2.png",
            "https://cdn.dummyjson.com/products/images/vehicle/300%20Touring/3.png",
            "https://cdn.dummyjson.com/products/images/vehicle/300%20Touring/4.png",
            "https://cdn.dummyjson.com/products/images/vehicle/300%20Touring/5.png",
            "https://cdn.dummyjson.com/products/images/vehicle/300%20Touring/6.png"
        ]',
        'https://cdn.dummyjson.com/products/images/vehicle/300%20Touring/thumbnail.png',
        NULL
    ),
    (
        'American Football',
        'The American Football is a classic ball used in American football games. It is designed for throwing and catching, making it an essential piece of equipment for the sport.',
        19.99,
        10.28,
        3.8,
        48,
        '["sports equipment", "american football"]',
        NULL,
        'QLDVAXMJ',
        9.00,
        '{"width": 9.74, "height": 23.16, "depth": 26.86}',
        '1 month warranty',
        'Ships in 2 weeks',
        'In Stock',
        '[
            {"rating": 4, "comment": "Excellent quality!", "date": "2024-05-23T08:56:21.625Z", "reviewerName": "Jaxon Barnes", "reviewerEmail": "jaxon.barnes@x.dummyjson.com"},
            {"rating": 4, "comment": "Great product!", "date": "2024-05-23T08:56:21.625Z", "reviewerName": "Aurora Lawson", "reviewerEmail": "aurora.lawson@x.dummyjson.com"},
            {"rating": 4, "comment": "Awesome product!", "date": "2024-05-23T08:56:21.625Z", "reviewerName": "Evan Reed", "reviewerEmail": "evan.reed@x.dummyjson.com"}
        ]',
        '30 days return policy',
        23,
        '["https://cdn.dummyjson.com/products/images/sports-accessories/American%20Football/1.png"]',
        'https://cdn.dummyjson.com/products/images/sports-accessories/American%20Football/thumbnail.png',
        NULL
    ),
    (
        'Brown Leather Belt Watch',
        'The Brown Leather Belt Watch is a stylish timepiece with a classic design. Featuring a genuine leather strap and a sleek dial, it adds a touch of sophistication to your look.',
        89.99,
        15.01,
        4.5,
        69,
        '["watches", "leather watches"]',
        'Fashion Timepieces',
        'WGZ21MSA',
        10.00,
        '{"width": 18.39, "height": 10.82, "depth": 10.52}',
        '3 months warranty',
        'Ships in 1 week',
        'In Stock',
        '[
            {"rating": 3, "comment": "Very dissatisfied!", "date": "2024-05-23T08:56:21.624Z", "reviewerName": "Oscar Powers", "reviewerEmail": "oscar.powers@x.dummyjson.com"},
            {"rating": 4, "comment": "Fast shipping!", "date": "2024-05-23T08:56:21.624Z", "reviewerName": "Eli Ward", "reviewerEmail": "eli.ward@x.dummyjson.com"},
            {"rating": 4, "comment": "Highly impressed!", "date": "2024-05-23T08:56:21.624Z", "reviewerName": "Stella Hughes", "reviewerEmail": "stella.hughes@x.dummyjson.com"}
        ]',
        '90 days return policy',
        10,
        '[
            "https://cdn.dummyjson.com/products/images/mens-watches/Brown%20Leather%20Belt%20Watch/1.png",
            "https://cdn.dummyjson.com/products/images/mens-watches/Brown%20Leather%20Belt%20Watch/2.png",
            "https://cdn.dummyjson.com/products/images/mens-watches/Brown%20Leather%20Belt%20Watch/3.png"
        ]',
        'https://cdn.dummyjson.com/products/images/mens-watches/Brown%20Leather%20Belt%20Watch/thumbnail.png',
        NULL
    ),
    (
        'IWC Ingenieur Automatic Steel',
        'The IWC Ingenieur Automatic Steel watch is a durable and sophisticated timepiece. With a stainless steel case and automatic movement, it combines precision and style for watch enthusiasts.',
        4999.99,
        5.76,
        2.6,
        85,
        '["watches", "luxury watches"]',
        'IWC',
        'OJF7AK1J',
        4.00,
        '{"width": 12.27, "height": 5.91, "depth": 8.71}',
        '5 year warranty',
        'Ships in 1 week',
        'In Stock',
        NULL,
        'No return policy',
        1,
        NULL,
        'https://cdn.dummyjson.com/products/images/womens-watches/IWC%20Ingenieur%20Automatic%20Steel/thumbnail.png',
        NULL
    ),
    (
        'Black & Brown Slipper',
        'The Black & Brown Slipper is a comfortable and stylish choice for casual wear. Featuring a blend of black and brown colors, it adds a touch of sophistication to your relaxation.',
        19.99,
        13.62,
        4.1,
        80,
        '["footwear", "slippers"]',
        'Comfort Trends',
        '0EVS1LOK',
        9.00,
        '{"width": 9.73, "height": 15.40, "depth": 6.30}',
        '2 year warranty',
        'Ships in 1-2 business days',
        'In Stock',
        NULL,
        '90 days return policy',
        29,
        NULL,
        'https://cdn.dummyjson.com/products/images/womens-shoes/Black%20&%20Brown%20Slipper/thumbnail.png',
        NULL
    ),
    (
        'Blue Frock',
        'The Blue Frock is a charming and stylish dress for various occasions. With a vibrant blue color and a comfortable design, it adds a touch of elegance to your wardrobe.',
        29.99,
        9.37,
        3.6,
        37,
        '["clothing", "dresses"]',
        NULL,
        'YAXY0OOO',
        2.00,
        '{"width": 22.85, "height": 26.97, "depth": 12.29}',
        '1 week warranty',
        'Ships in 1 week',
        'In Stock',
        NULL,
        '7 days return policy',
        19,
        NULL,
        'https://cdn.dummyjson.com/products/images/tops/Blue%20Frock/thumbnail.png',
        NULL
    ),
    (
        'Green Crystal Earring',
        'The Green Crystal Earring is a dazzling accessory that features a vibrant green crystal. With a classic design, it adds a touch of elegance to your ensemble, perfect for formal or special occasions.',
        29.99,
        2.58,
        2.9,
        1,
        '["fashion accessories", "earrings"]',
        NULL,
        'O7LSKAP2',
        10.00,
        '{"width": 19.73, "height": 14.54, "depth": 15.92}',
        '3 year warranty',
        'Ships in 1 month',
        'Low Stock',
        NULL,
        '30 days return policy',
        17,
        NULL,
        'https://cdn.dummyjson.com/products/images/womens-jewellery/Green%20Crystal%20Earring/thumbnail.png',
        NULL
    ),
    (
        'Black Women''s Gown',
        'The Black Women''s Gown is an elegant and timeless evening gown. With a sleek black design, it''s perfect for formal events and special occasions, exuding sophistication and style.',
        129.99,
        5.86,
        4.8,
        59,
        '["clothing", "gowns"]',
        NULL,
        'CL0LXEBG',
        7.00,
        '{"width": 22.40, "height": 22.15, "depth": 21.87}',
        'Lifetime warranty',
        'Ships in 1 month',
        'In Stock',
        NULL,
        '7 days return policy',
        2,
        NULL,
        'https://cdn.dummyjson.com/products/images/womens-dresses/Black%20Women''s%20Gown/thumbnail.png',
        NULL
    );