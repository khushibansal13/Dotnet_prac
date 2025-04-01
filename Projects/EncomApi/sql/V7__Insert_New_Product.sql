INSERT INTO Products (
    Id,
    Title,
    Description,
    Price,
    DiscountPercentage,
    Rating,
    Stock,
    Tags,
    Brand,
    Sku,
    Weight,
    Dimensions,
    WarrantyInformation,
    ShippingInformation,
    AvailabilityStatus,
    Reviews,
    ReturnPolicy,
    MinimumOrderQuantity,
    Images,
    Thumbnail,
    CategoryId
) VALUES
    (
    121,
    'iPhone 5s',
    'The iPhone 5s is a classic smartphone known for its compact design and advanced features during its release. While it\'s an older model, it still provides a reliable user experience.',
    199.99,
    11.85,
    3.92,
    65,
    '["smartphones", "apple"]',
    'Apple',
    'AZ1L68SM',
    4,
    '{"width": 8.49, "height": 25.34, "depth": 18.12}',
    '1 week warranty',
    'Ships in 1 week',
    'In Stock',
    '[
        {"rating": 4, "comment": "Highly impressed!", "date": "2024-05-23T08:56:21.625Z", "reviewerName": "Wyatt Perry", "reviewerEmail": "wyatt.perry@x.dummyjson.com"},
        {"rating": 5, "comment": "Awesome product!", "date": "2024-05-23T08:56:21.625Z", "reviewerName": "Olivia Anderson", "reviewerEmail": "olivia.anderson@x.dummyjson.com"},
        {"rating": 4, "comment": "Highly recommended!", "date": "2024-05-23T08:56:21.625Z", "reviewerName": "Mateo Nguyen", "reviewerEmail": "mateo.nguyen@x.dummyjson.com"}
    ]',
    'No return policy',
    2,
    '[
        "https://cdn.dummyjson.com/products/images/smartphones/iPhone%205s/1.png",
        "https://cdn.dummyjson.com/products/images/smartphones/iPhone%205s/2.png",
        "https://cdn.dummyjson.com/products/images/smartphones/iPhone%205s/3.png"
    ]',
    'https://cdn.dummyjson.com/products/images/smartphones/iPhone%205s/thumbnail.png',
    (SELECT Id FROM Categories WHERE Name = 'smartphones' LIMIT 1)
),
(
    122,
    'Samsung Galaxy S21',
    'The Samsung Galaxy S21 features a pro-grade camera system, 8K video capabilities, and a sleek design.',
    799.99,
    10.00,
    4.75,
    34,
    '["smartphones", "samsung"]',
    'Samsung',
    'SGS21ZSM',
    5,
    '{"width": 7.76, "height": 16.51, "depth": 0.91}',
    '1 year warranty',
    'Ships within 3 days',
    'In Stock',
    '[
        {"rating": 5, "comment": "Best phone ever!", "date": "2024-05-23T08:56:21.625Z", "reviewerName": "Liam Johnson", "reviewerEmail": "liam.johnson@x.dummyjson.com"},
        {"rating": 4, "comment": "Satisfied with the performance!", "date": "2024-05-23T08:56:21.625Z", "reviewerName": "Emma Wilson", "reviewerEmail": "emma.wilson@x.dummyjson.com"}
    ]',
    '30 days return policy',
    1,
    '[
        "https://cdn.dummyjson.com/products/images/smartphones/Samsung%20Galaxy%20S21/1.png",
        "https://cdn.dummyjson.com/products/images/smartphones/Samsung%20Galaxy%20S21/2.png",
        "https://cdn.dummyjson.com/products/images/smartphones/Samsung%20Galaxy%20S21/3.png"
    ]',
    'https://cdn.dummyjson.com/products/images/smartphones/Samsung%20Galaxy%20S21/thumbnail.png',
    (SELECT Id FROM Categories WHERE Name = 'smartphones' LIMIT 1)
),
(
    123,
    'MacBook Air M2',
    'Apple MacBook Air M2 is a lightweight laptop with a powerful chip for seamless performance and extended battery life.',
    1199.99,
    5.00,
    4.85,
    20,
    '["laptops", "apple"]',
    'Apple',
    'MBA2APL',
    10,
    '{"width": 30.41, "height": 21.24, "depth": 1.13}',
    '1 year warranty',
    'Ships within 5 days',
    'In Stock',
    '[
        {"rating": 5, "comment": "Incredible performance!", "date": "2024-05-23T08:56:21.625Z", "reviewerName": "Sophia Martinez", "reviewerEmail": "sophia.martinez@x.dummyjson.com"},
        {"rating": 5, "comment": "Worth every penny!", "date": "2024-05-23T08:56:21.625Z", "reviewerName": "Ethan Brown", "reviewerEmail": "ethan.brown@x.dummyjson.com"}
    ]',
    '14 days return policy',
    1,
    '[
        "https://cdn.dummyjson.com/products/images/laptops/MacBook%20Air%20M2/1.png",
        "https://cdn.dummyjson.com/products/images/laptops/MacBook%20Air%20M2/2.png",
        "https://cdn.dummyjson.com/products/images/laptops/MacBook%20Air%20M2/3.png"
    ]',
    'https://cdn.dummyjson.com/products/images/laptops/MacBook%20Air%20M2/thumbnail.png',
    (SELECT Id FROM Categories WHERE Name = 'laptops' LIMIT 1)
);
