use [NovinMeyar.Common]

GO
set IDENTITY_INSERT [dbo].[Provinces] on

INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (1, N'آذربایجان شرقی')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (2, N'آذربایجان غربی')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (19, N'اردبیل')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (6, N'اصفهان')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (9, N'البرز')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (30, N'ایلام')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (24, N'بوشهر')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (5, N'تهران')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (27, N'چهارمحال و بختیاری')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (10, N'خراسان جنوبی')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (3, N'خراسان رضوی')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (8, N'خراسان شمالی')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (12, N'خوزستان')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (17, N'زنجان')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (14, N'سمنان')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (29, N'سیستان و بلوچستان')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (7, N'فارس')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (13, N'قزوین')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (15, N'قم')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (25, N'كرمان')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (22, N'كرمانشاه')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (31, N'كهكیلویه و بویراحمد')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (18, N'گلستان')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (11, N'گیلان')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (23, N'لرستان')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (4, N'مازندران')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (16, N'مرکزی')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (26, N'هرمزگان')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (20, N'همدان')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (21, N'کردستان')
GO
INSERT [dbo].[Provinces] ([Id], [Name]) VALUES (28, N'یزد')

GO

GO
set IDENTITY_INSERT [dbo].[Cities] on

INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1, 5, N'تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2, 1, N'تبریز ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (3, 2, N'ارومیه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (4, 3, N'مشهد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (5, 4, N'ساری')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (6, 6, N'اصفهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (7, 7, N'شیراز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (8, 4, N'چالوس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (9, 4, N'آمل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (10, 9, N'کرج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (11, 25, N'كرمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (12, 22, N'کرمانشاه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (13, 10, N'بیرجند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (14, 12, N'اهواز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (15, 13, N'قزوین')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (16, 14, N'سمنان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (17, 14, N'شاهرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (18, 15, N'قم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (19, 16, N'اراك')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (20, 16, N'ساوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (21, 17, N'زنجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (22, 4, N'بابل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (23, 18, N'گرگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (24, 19, N'اردبیل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (25, 12, N'ابادان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (26, 12, N'خرمشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (27, 20, N'همدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (28, 21, N'سنندج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (29, 23, N'خرم اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (30, 23, N'بروجرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (31, 25, N'رفسنجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (32, 25, N'سیرجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (33, 26, N'بندرعباس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (34, 27, N'شهركرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (35, 28, N'یزد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (36, 29, N'زاهدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (37, 29, N'ایرانشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (38, 13, N'الوند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (39, 13, N'ابیك')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (40, 13, N'بوئینزهرا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (41, 13, N'اوج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (42, 13, N'تاكستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (43, 13, N'محمدیه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (44, 14, N'علا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (45, 14, N'ابخوری')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (46, 14, N'سرخه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (47, 14, N'مهدیشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (48, 14, N'شهمیرزاد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (49, 14, N'گرمسار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (50, 14, N'ایوانكی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (51, 14, N'میامی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (52, 14, N'بسطام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (53, 14, N'مجن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (54, 14, N'بیارجمند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (55, 14, N'دامغان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (56, 14, N'امیریه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (57, 8, N'بجنورد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (58, 6, N'نصرآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (59, 6, N'سپاهان شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (60, 6, N'دستگرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (61, 6, N'خسروآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (62, 6, N'محمدآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (63, 6, N'کوشِک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (64, 6, N'حسن آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (65, 6, N'مهاباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (66, 6, N'شهراب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (67, 6, N'کریم آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (68, 6, N'رضوان شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (69, 1, N'میانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (70, 1, N'مرند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (71, 1, N'مراغه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (72, 1, N'شهر جديد سهند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (73, 1, N'اُسکو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (74, 1, N'سَردرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (75, 1, N'آذرشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (76, 1, N'شبستر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (77, 1, N'هِریس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (78, 1, N'هادی شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (79, 1, N'جُلفا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (80, 1, N'اَهَر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (81, 1, N'کَلیبَر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (82, 1, N'سراب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (83, 1, N'بُستان آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (84, 1, N'عجب شیر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (85, 1, N'بُناب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (86, 1, N'مَلِکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (87, 1, N'هشترود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (88, 1, N'قره آغاج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (89, 1, N'آغچه ریش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (90, 1, N'تُرک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (91, 1, N'تُرکَمانچای')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (92, 1, N'خاتون آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (93, 1, N'شیخدارآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (94, 1, N'قره بلاغ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (95, 1, N'آقکَند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (96, 1, N'اچاچی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (97, 1, N'گوندوغدی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (98, 1, N'پورسَخلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (99, 1, N'کنگاور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (100, 1, N'قویوجاق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (101, 1, N'اَرموداق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (102, 1, N'کَهنِمو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (103, 1, N'اَربَط')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (104, 1, N'خسروشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (105, 1, N'لاهیجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (106, 1, N'خاص آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (107, 1, N'ایلخچی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (108, 1, N'سرای(سرای دِه)')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (109, 1, N'کُجوار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (110, 1, N'خلجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (111, 1, N'یِنگی اِسپِران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (112, 1, N'باسمَنج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (113, 1, N'شادبادمشایخ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (114, 1, N'کَندرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (115, 1, N'مایان سُفلی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (116, 1, N'تیمورلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (117, 1, N'خَراجو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (118, 1, N'قدمگاه(بادام یار)')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (119, 1, N'ممقان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (120, 1, N'گوگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (121, 1, N'شیرامین')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (122, 1, N'هفت چشمه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (123, 1, N'وایقان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (124, 1, N'امند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (125, 1, N'کوزه کنان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (126, 1, N'خامنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (127, 1, N'ااا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (128, 1, N'صوفیان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (129, 1, N'شَندآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (130, 1, N'تَسوج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (131, 1, N'شرفخانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (132, 1, N'مینَق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (133, 1, N'کُلوَناق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (134, 1, N'بخشایش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (135, 1, N'سرند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (136, 1, N'زرنق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (137, 1, N'بیلوَردی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (138, 1, N'خواجه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (139, 1, N'گلین قیه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (140, 1, N'هَرزند جدید')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (141, 1, N'بناب جدید')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (142, 1, N'زَنوز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (143, 1, N'دولت آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (144, 1, N'یکان کهریز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (145, 1, N'یامچی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (146, 1, N'شیجاع')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (147, 1, N'دالان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (148, 1, N'سیه رود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (149, 1, N'نوجه مهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (150, 1, N'کشکسرای')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (151, 1, N'خاروانا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (152, 1, N'هوراند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (153, 1, N'چول قشلاق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (154, 1, N'ورگاهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (155, 1, N'اَفیل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (156, 1, N'اذغان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (157, 1, N'سیه کلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (158, 1, N'ورزقان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (159, 1, N'آق براز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (160, 1, N'مولان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (161, 1, N'خمارلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (162, 1, N'عاشقلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (163, 1, N'اَسگلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (164, 1, N'آبش احمد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (165, 1, N'یوزبند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (166, 1, N'شهرک صنعتی کاغذکنان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (167, 1, N'کندوان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (168, 1, N'تیل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (169, 1, N'لاریجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (170, 1, N'اسب فروشان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (171, 1, N'ابرغان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (172, 1, N'دوزدوزان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (173, 1, N'شربیان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (174, 1, N'مهربان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (175, 1, N'رازلیق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (176, 1, N'اغمیون')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (177, 1, N'اردها')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (178, 1, N'قره چای حاج علی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (179, 1, N'قره بابا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (180, 1, N'سعید آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (181, 1, N'الانَق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (182, 1, N'کردکندی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (183, 1, N'تیکمه داش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (184, 1, N'قره چمن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (185, 1, N'وَرجوی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (186, 1, N'گل تپه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (187, 1, N'خداجو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (188, 1, N'داش بلاغ بازار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (189, 1, N'صومعه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (190, 1, N'علویان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (191, 1, N'شیراز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (192, 1, N'خضرلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (193, 1, N'یِگُنجه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (194, 1, N'مهماندار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (195, 1, N'خانیان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (196, 1, N'دانالو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (197, 1, N'رحمانلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (198, 1, N'زاوشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (199, 1, N'اَلقو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (200, 1, N'روشت بزرگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (201, 1, N'خوشه مهر (خواجه امیر)')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (202, 1, N'زوارق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (203, 1, N'شورخانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (204, 1, N'لکلَر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (205, 1, N'آق منار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (206, 1, N'لیکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (207, 1, N'طوراغایی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (208, 1, N'اوشندِل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (209, 1, N'علی آباد عُلیا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (210, 1, N'ذوالبین')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (211, 1, N'نظر کهریزی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (212, 1, N'آتش بیگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (213, 1, N'سُلوک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (214, 1, N'نصیرآباد سُفلی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (215, 1, N'ارسگنای سُفلی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (216, 1, N'سلطان آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (217, 1, N'قلعه حسین آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (218, 1, N'ذاکرکَندی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (219, 1, N'قوچ احمد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (220, 1, N'آغ زیارت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (221, 5, N'اسلام شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (222, 5, N'منطقه 11 پستي تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (223, 5, N'منطقه 13 پستي تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (224, 5, N'منطقه 14 پستي تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (225, 5, N'منطقه 15 پستي تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (226, 5, N'منطقه 16 پستي تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (227, 5, N'منطقه 17 پستي تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (228, 5, N'منطقه 18 پستي تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (229, 5, N'منطقه 19 پستي تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (230, 5, N'ری')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (231, 5, N'لواسان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (232, 5, N'شهريار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (233, 5, N'ورامين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (234, 5, N'پيشوا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (235, 5, N'پاکدشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (236, 5, N'قدس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (237, 5, N'رباط کريم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (238, 5, N'دماوند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (239, 5, N'فيروزکوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (240, 5, N'جاجرود(خسروآباد)')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (241, 5, N'بومهن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (242, 5, N'شهرصنعتي خرمدشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (243, 5, N'پرديس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (244, 5, N'باقر شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (245, 5, N'جعفرابادباقراف')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (246, 5, N'مرقدامام ره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (247, 5, N'کهريزک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (248, 5, N'طورقوزاباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (249, 5, N'قاسم ابادشوراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (250, 5, N'قمصر-تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (251, 5, N'حسن آباد-تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (252, 5, N'شمس اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (253, 5, N'ابراهيم اباد-تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (254, 5, N'چرمشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (255, 5, N'قلعه محمدعلي خان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (256, 5, N'فرودگاه امام خميني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (257, 5, N'وهن اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (258, 5, N'قلعه نوخالصه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (259, 5, N'گل تپه کبير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (260, 5, N'محمودابادپيرزاده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (261, 5, N'فرون اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (262, 5, N'خاورشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (263, 5, N'اسلام اباد-تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (264, 5, N'لپه زنگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (265, 5, N'قيامدشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (266, 5, N'قرچک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (267, 5, N'قو,چ حصار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (268, 5, N'خلازير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (269, 5, N'تجريش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (270, 5, N'نصيرشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (271, 5, N'شهرک صنعتي نصيرشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (272, 5, N'شهرک قلعه مير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (273, 5, N'صفادشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (274, 5, N'انديشه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (275, 5, N'ملارد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (276, 5, N'گرمدره-تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (277, 5, N'احمدابادمستوفي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (278, 5, N'فيروزبهرام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (279, 5, N'گلدسته')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (280, 5, N'صالح آباد-تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (281, 5, N'شاطره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (282, 5, N'چهاردانگه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (283, 5, N'سعيدآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (284, 5, N'فشم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (285, 5, N'لواسان بزرگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (286, 5, N'باغستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (287, 5, N'صباشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (288, 5, N'شاهدشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (289, 5, N'فردوسيه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (290, 5, N'وحيديه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (291, 5, N'لم اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (292, 5, N'قلعه سين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (293, 5, N'عسگرابادعباسی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (294, 5, N'دهماسين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (295, 5, N'باغ خواص')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (296, 5, N'ايجدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (297, 5, N'آب باريک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (298, 5, N'جواد آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (299, 5, N'خاوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (300, 5, N'جليل اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (301, 5, N'کريم اباد-تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (302, 5, N'قلعه خواجه-تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (303, 5, N'شهرک عباس آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (304, 5, N'داوداباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (305, 5, N'شريف آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (306, 5, N'پارچين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (307, 5, N'حصارامير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (308, 5, N'خاتون اباد-تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (309, 5, N'نصيرآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (310, 5, N'گلستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (311, 5, N'کلمه-تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (312, 5, N'پرند(رباط کریم)')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (313, 5, N'شهر صنعتي پرند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (314, 5, N'سلطان اباد-تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (315, 5, N'حصارک پايين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (316, 5, N'نسيم شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (317, 5, N'حصارک بالا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (318, 5, N'سبزدشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (319, 5, N'احمدآبادجانسپار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (320, 5, N'اسماعيل آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (321, 5, N'جابان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (322, 5, N'رودهن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (323, 5, N'آبعلی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (324, 5, N'کيلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (325, 5, N'آبسرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (326, 5, N'سربندان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (327, 5, N'مهرآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (328, 5, N'مشا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (329, 5, N'مرا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (330, 5, N'هرانده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (331, 5, N'درده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (332, 5, N'حصاربن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (333, 5, N'ارجمند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (334, 5, N'اميريه-تهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (335, 9, N'نظرآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (336, 9, N'هشتگرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (337, 9, N'ادران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (338, 9, N'آسارا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (339, 9, N'گرمدره-البرز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (340, 9, N'فردیس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (341, 9, N'مشکين دشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (342, 9, N'محمدشهر-البرز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (343, 9, N'کرج-(مهرشهر)')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (344, 9, N'ماهدشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (345, 9, N'اشتهارد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (346, 9, N'کمالشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (347, 9, N'تنکمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (348, 9, N'گلسار(سیف آباد)')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (349, 9, N'شهرجديدهشتگرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (350, 9, N'کوهسار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (351, 9, N'چهارباغ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (352, 9, N'طالقان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (353, 6, N'شاهين شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (354, 6, N'خميني شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (355, 6, N'نجف آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (356, 6, N'شهرضا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (357, 6, N'کاشان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (358, 6, N'منطقه صنعتي محموداباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (359, 6, N'مورچه خورت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (360, 6, N'دولت آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (361, 6, N'ميمه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (362, 6, N'خور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (363, 6, N'کوهپايه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (364, 6, N'اردستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (365, 6, N'نائین')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (366, 6, N'درچه پياز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (367, 6, N'زواره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (368, 6, N'فلاورجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (369, 6, N'قهدريجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (370, 6, N'زرين شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (371, 6, N'مبارکه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (372, 6, N'فولادشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (373, 6, N'تيران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (374, 6, N'دهق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (375, 6, N'علويجه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (376, 6, N'چادگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (377, 6, N'فريدونشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (378, 6, N'دهاقان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (379, 6, N'اسفرجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (380, 6, N'سميرم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (381, 6, N'حنا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (382, 6, N'جوشقان استرک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (383, 6, N'آران و بيدگل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (384, 6, N'قمصر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (385, 6, N'نطنز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (386, 6, N'گلپايگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (387, 6, N'گوگد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (388, 6, N'خوانسار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (389, 6, N'تودشک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (390, 6, N'سگزی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (391, 6, N'بهارستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (392, 6, N'خوراسگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (393, 6, N'گورت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (394, 6, N'دستجا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (395, 6, N'زيار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (396, 6, N'ابريشم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (397, 6, N'پادگان اموزشي امام ص')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (398, 6, N'پالايشگاه اصفهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (399, 6, N'کلهرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (400, 6, N'گرگاب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (401, 6, N'گز برخوار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (402, 6, N'خورزوق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (403, 6, N'حبيب آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (404, 6, N'موته')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (405, 6, N'وزوان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (406, 6, N'لاي بيد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (407, 6, N'رباطاقاکمال')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (408, 6, N'کمشچه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (409, 6, N'جندق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (410, 6, N'فرخی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (411, 6, N'مزيک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (412, 6, N'مهرجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (413, 6, N'بياضه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (414, 6, N'چوپانان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (415, 6, N'بلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (416, 6, N'هرند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (417, 6, N'ورزنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (418, 6, N'قهجاورستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (419, 6, N'نيک آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (420, 6, N'اژيه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (421, 6, N'کچومثقال')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (422, 6, N'ظفرقند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (423, 6, N'نهوج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (424, 6, N'نيسيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (425, 6, N'ومکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (426, 6, N'همسار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (427, 6, N'فسخود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (428, 6, N'فوداز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (429, 6, N'اشکستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (430, 6, N'کجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (431, 6, N'نيستانک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (432, 6, N'انارک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (433, 6, N'بافران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (434, 6, N'تيرانچی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (435, 6, N'قلعه اميريه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (436, 6, N'درقه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (437, 6, N'تورزن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (438, 6, N'تلک اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (439, 6, N'موغار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (440, 6, N'خوانسارک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (441, 6, N'پيربکران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (442, 6, N'کليشادوسودرجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (443, 6, N'کرسگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (444, 6, N'بهاران شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (445, 6, N'سهروفيروزان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (446, 6, N'ايمانشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (447, 6, N'زازران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (448, 6, N'شرودان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (449, 6, N'جوجيل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (450, 6, N'ورنامخواست')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (451, 6, N'سده لنجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (452, 6, N'چرمهين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (453, 6, N'باغ بهادران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (454, 6, N'نوگوران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (455, 6, N'چمگردان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (456, 6, N'کرچگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (457, 6, N'ديزيچه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (458, 6, N'زيباشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (459, 6, N'باغ ملک-اصفهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (460, 6, N'دهسرخ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (461, 6, N'پلی اکريل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (462, 6, N'فولادمبارکه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (463, 6, N'کرکوند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (464, 6, N'زاينده رود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (465, 6, N'چم نور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (466, 6, N'کچوييه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (467, 6, N'طالخونچه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (468, 6, N'تاسيسات سدنکواباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (469, 6, N'ورپشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (470, 6, N'عسگران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (471, 6, N'عزیزاباد-اصفهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (472, 6, N'ميراباد-اصفهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (473, 6, N'حاجی آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (474, 6, N'اشن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (475, 6, N'خونداب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (476, 6, N'حسین آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (477, 6, N'غرغن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (478, 6, N'دامنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (479, 6, N'بوئین و میاندشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (480, 6, N'زرنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (481, 6, N'بلطاق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (482, 6, N'کرچ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (483, 6, N'قره بلطاق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (484, 6, N'افوس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (485, 6, N'سازمان عمران زاينده رود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (486, 6, N'مشهدکاوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (487, 6, N'اسکندری')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (488, 6, N'رزوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (489, 6, N'نهرخلج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (490, 6, N'چاه غلامرضارحيمی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (491, 6, N'اورگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (492, 6, N'گلدشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (493, 6, N'جوزدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (494, 6, N'کهریزسنگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (495, 6, N'نهضت آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (496, 6, N'قلعه سرخ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (497, 6, N'اسلام ابادموگویی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (498, 6, N'مصیر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (499, 6, N'برف انبار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (500, 6, N'قمشلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (501, 6, N'پوده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (502, 6, N'مهيار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (503, 6, N'پرزان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (504, 6, N'منوچهرآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (505, 6, N'شهرک صنایع شیمیایی رازی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (506, 6, N'همگین')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (507, 6, N'گلشن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (508, 6, N'کهرويه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (509, 6, N'قصرچم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (510, 6, N'امين اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (511, 6, N'مقصودبيک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (512, 6, N'سولار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (513, 6, N'منظریه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (514, 6, N'گرموک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (515, 6, N'هست')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (516, 6, N'ونک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (517, 6, N'کهنگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (518, 6, N'کمه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (519, 6, N'مورک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (520, 6, N'چهارراه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (521, 6, N'ده نسا سفلی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (522, 6, N'اغداش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (523, 6, N'چشمه رحمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (524, 6, N'ورق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (525, 6, N'سعادت آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (526, 6, N'فتح آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (527, 6, N'نياسر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (528, 6, N'سن سن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (529, 6, N'ده زيره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (530, 6, N'رحق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (531, 6, N'آب شيرين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (532, 6, N'نشلج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (533, 6, N'مشکات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (534, 6, N'سفیدشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (535, 6, N'مزرعه صدر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (536, 6, N'نوش آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (537, 6, N'ابوزيدآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (538, 6, N'کاغذی')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (539, 6, N'قهرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (540, 6, N'جوشقان و کامو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (541, 6, N'برزک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (542, 6, N'اسحق اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (543, 6, N'وادقان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (544, 6, N'اذران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (545, 6, N'طرق رود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (546, 6, N'اريسمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (547, 6, N'ابيانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (548, 6, N'بادرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (549, 6, N'خالدآ باد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (550, 6, N'اوره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (551, 6, N'ملازجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (552, 6, N'سعیدآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (553, 6, N'مَرغ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (554, 6, N'قرغن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (555, 6, N'کوچری')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (556, 6, N'کلوچان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (557, 6, N'گلشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (558, 6, N'زرنجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (559, 6, N'وانشان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (560, 6, N'تيکَن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (561, 6, N'سنگ سفيد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (562, 6, N'رحمت آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (563, 6, N'خم پیچ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (564, 6, N'مهرآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (565, 6, N'تيدجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (566, 6, N'خشکرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (567, 6, N'ويست')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (568, 7, N'کازرون')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (569, 7, N'جهرم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (570, 7, N'قائميه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (571, 7, N'زرقان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (572, 7, N'نور آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (573, 7, N'اردکان-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (574, 7, N'مرودشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (575, 7, N'اقليد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (576, 7, N'آباده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (577, 7, N'لار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (578, 7, N'گراش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (579, 7, N'استهبان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (580, 7, N'فسا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (581, 7, N'فيروز آباد-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (582, 7, N'داراب-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (583, 7, N'ني ريز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (584, 7, N'بندامير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (585, 7, N'خيرابادتوللي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (586, 7, N'داريان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (587, 7, N'کم جان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (588, 7, N'شوريجه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (589, 7, N'مهارلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (590, 7, N'کوهنجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (591, 7, N'سلطان آباد-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (592, 7, N'تفيهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (593, 7, N'طسوج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (594, 7, N'اکبراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (595, 7, N'مظفري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (596, 7, N'کوشک بيدک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (597, 7, N'فتح اباد-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (598, 7, N'ده شيب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (599, 7, N'خانه زنيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (600, 7, N'پاسگاه چنارراهدار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (601, 7, N'موردراز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (602, 7, N'شهرجديدصدرا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (603, 7, N'کلاتون')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (604, 7, N'کلاني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (605, 7, N'کمارج مرکزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (606, 7, N'مهبودي عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (607, 7, N'وراوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (608, 7, N'حکيم باشي نصف ميان (بالا)')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (609, 7, N'کنار تخته')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (610, 7, N'خشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (611, 7, N'انارستان-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (612, 7, N'نودان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (613, 7, N'مهرنجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (614, 7, N'جره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (615, 7, N'بالاده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (616, 7, N'لپوئي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (617, 7, N'کامفيروز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (618, 7, N'خرامه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (619, 7, N'سروستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (620, 7, N'کوار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (621, 7, N'رامجرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (622, 7, N'گويم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (623, 7, N'خومه زار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (624, 7, N'بابامنير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (625, 7, N'اهنگري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (626, 7, N'پرين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (627, 7, N'کوپن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (628, 7, N'حسين ابادرستم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (629, 7, N'مصيري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (630, 7, N'ميشان سفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (631, 7, N'بهرغان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (632, 7, N'بيضا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (633, 7, N'هماشهر-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (634, 7, N'کمهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (635, 7, N'راشک عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (636, 7, N'هرايجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (637, 7, N'بانش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (638, 7, N'کوشک-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (639, 7, N'خانيمن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (640, 7, N'سعادت شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (641, 7, N'قادرآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (642, 7, N'ارسنجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (643, 7, N'سيدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (644, 7, N'کوشکک-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (645, 7, N'مزايجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (646, 7, N'خنجشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (647, 7, N'امامزاده اسماعيل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (648, 7, N'مادرسليمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (649, 7, N'حسن آباد-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (650, 7, N'اسپاس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (651, 7, N'سده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (652, 7, N'دژکرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (653, 7, N'شهرميان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (654, 7, N'بهمن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (655, 7, N'صغاد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (656, 7, N'حسامي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (657, 7, N'بوانات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (658, 7, N'کره اي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (659, 7, N'صفاشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (660, 7, N'سورمق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (661, 7, N'ايزدخواست')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (662, 7, N'دوزه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (663, 7, N'بندبست')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (664, 7, N'باب انار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (665, 7, N'فيشور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (666, 7, N'اوز-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (667, 7, N'لامرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (668, 7, N'جويم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (669, 7, N'بنارويه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (670, 7, N'خور-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (671, 7, N'لطيفي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (672, 7, N'عمادده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (673, 7, N'بيرم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (674, 7, N'اهل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (675, 7, N'اشکنان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (676, 7, N'اسير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (677, 7, N'کهنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (678, 7, N'خوزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (679, 7, N'خنج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (680, 7, N'علامرودشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (681, 7, N'گله دار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (682, 7, N'مهر-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (683, 7, N'رونيز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (684, 7, N'بنوان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (685, 7, N'ايج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (686, 7, N'درب قلعه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (687, 7, N'خاوران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (688, 7, N'قطب آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (689, 7, N'دنيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (690, 7, N'سروو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (691, 7, N'مانيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (692, 7, N'به جان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (693, 7, N'کوشک قاضي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (694, 7, N'نوبندگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (695, 7, N'قره بلاغ-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (696, 7, N'ششده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (697, 7, N'قاسم ابادسفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (698, 7, N'زاهدشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (699, 7, N'ميانده-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (700, 7, N'صحرارود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (701, 7, N'بايگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (702, 7, N'امام شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (703, 7, N'مبارک آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (704, 7, N'ميمند-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (705, 7, N'افزر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (706, 7, N'قير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (707, 7, N'کارزين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (708, 7, N'فراشبند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (709, 7, N'نوجين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (710, 7, N'دهرم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (711, 7, N'جوکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (712, 7, N'مادوان-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (713, 7, N'دبيران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (714, 7, N'ماه سالاري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (715, 7, N'رستاق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (716, 7, N'شهرپير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (717, 7, N'حاجي آباد-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (718, 7, N'فدامي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (719, 7, N'دوبرجي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (720, 7, N'چمن مرواريد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (721, 7, N'جنت شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (722, 7, N'لاي حنا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (723, 7, N'آباده طشک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (724, 7, N'قطاربنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (725, 7, N'مشکان-فارس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (726, 7, N'قطرويه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (727, 7, N'هرگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (728, 3, N'نيشابور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (729, 3, N'تربت حيدريه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (730, 3, N'سبزوار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (731, 3, N'فيروزه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (732, 3, N'درود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (733, 3, N'طرقبه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (734, 3, N'چناران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (735, 3, N'کلات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (736, 3, N'سرخس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (737, 3, N'فريمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (738, 3, N'قوچان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (739, 3, N'درگز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (740, 3, N'فيض آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (741, 3, N'رشتخوار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (742, 3, N'کدکن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (743, 3, N'خواف')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (744, 3, N'تربت جام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (745, 3, N'صالح آباد-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (746, 3, N'تايباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (747, 3, N'داورزن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (748, 3, N'جغتاي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (749, 3, N'ششتمد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (750, 3, N'کاشمر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (751, 3, N'بردسکن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (752, 3, N'گناباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (753, 3, N'رضويه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (754, 3, N'همت آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (755, 3, N'شوراب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (756, 3, N'گلبوي پايين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (757, 3, N'مبارکه-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (758, 3, N'چکنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (759, 3, N'برزنون')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (760, 3, N'فديشه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (761, 3, N'بار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (762, 3, N'ميراباد-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (763, 3, N'فرخک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (764, 3, N'خرو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (765, 3, N'قدمگاه-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (766, 3, N'اسحق اباد-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (767, 3, N'خوجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (768, 3, N'عشق آباد-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (769, 3, N'ملک آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (770, 3, N'کورده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (771, 3, N'شانديز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (772, 3, N'طوس سفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (773, 3, N'قرقي سفلي (شهيدکاوه )')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (774, 3, N'کنه بيست')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (775, 3, N'رادکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (776, 3, N'سيداباد-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (777, 3, N'گلبهار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (778, 3, N'سلوگرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (779, 3, N'ارداک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (780, 3, N'بقمج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (781, 3, N'گلمکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (782, 3, N'ميامي-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (783, 3, N'چاهک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (784, 3, N'شهرزو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (785, 3, N'گوش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (786, 3, N'نريماني سفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (787, 3, N'تقي اباد-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (788, 3, N'کچولي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (789, 3, N'شيرتپه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (790, 3, N'پس کمر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (791, 3, N'مزدآوند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (792, 3, N'بزنگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (793, 3, N'گنبدلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (794, 3, N'کندک لي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (795, 3, N'کته شمشيرسفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (796, 3, N'سنگ بست')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (797, 3, N'سفيد سنگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (798, 3, N'قلندر آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (799, 3, N'فرهادگرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (800, 3, N'زرکک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (801, 3, N'شهرکهنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (802, 3, N'قريه شرف')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (803, 3, N'يدک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (804, 3, N'ديزاديز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (805, 3, N'شفيع')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (806, 3, N'دوغايي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (807, 3, N'جوزان-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (808, 3, N'امامقلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (809, 3, N'باجگيران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (810, 3, N'حسن ابادلايين نو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (811, 3, N'لطف آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (812, 3, N'کپکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (813, 3, N'چاپشلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (814, 3, N'نوخندان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (815, 3, N'شهرک زيندانلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (816, 3, N'محمدتقي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (817, 3, N'سيوکي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (818, 3, N'مهنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (819, 3, N'عبدل اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (820, 3, N'شادمهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (821, 3, N'بايک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (822, 3, N'چخماق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (823, 3, N'قلعه اقاحسن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (824, 3, N'زرغري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (825, 3, N'جنگل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (826, 3, N'باسفر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (827, 3, N'دولت آباد-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (828, 3, N'يک لنگي عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (829, 3, N'کامه سفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (830, 3, N'رودخانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (831, 3, N'رباط سنگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (832, 3, N'اسداباد-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (833, 3, N'نصر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (834, 3, N'نشتيفان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (835, 3, N'سنگان-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (836, 3, N'مژن اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (837, 3, N'قاسم آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (838, 3, N'چمن اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (839, 3, N'حسن اباد-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (840, 3, N'سلامي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (841, 3, N'چشمه گل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (842, 3, N'نيل شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (843, 3, N'احمدآبادصولت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (844, 3, N'نصرآباد-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (845, 3, N'ابدال اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (846, 3, N'کاريزنو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (847, 3, N'درزاب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (848, 3, N'محموداباد-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (849, 3, N'ياقوتين جديد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (850, 3, N'جنت اباد-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (851, 3, N'موسي اباد-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (852, 3, N'بني تاک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (853, 3, N'ازاده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (854, 3, N'کاريز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (855, 3, N'دوقارون')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (856, 3, N'کرات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (857, 3, N'مشهدريزه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (858, 3, N'باخرز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (859, 3, N'قلعه نو-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (860, 3, N'کوه سفيد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (861, 3, N'مهر-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (862, 3, N'رباطسرپوشي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (863, 3, N'مشکان-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (864, 3, N'نامن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (865, 3, N'روداب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (866, 3, N'مزينان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (867, 3, N'دستوران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (868, 3, N'ازادوار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (869, 3, N'راه چمن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (870, 3, N'انداده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (871, 3, N'نقاب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (872, 3, N'حکم اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (873, 3, N'برغمد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (874, 3, N'بلاشي اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (875, 3, N'نوده انقلاب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (876, 3, N'رباطجز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (877, 3, N'سلطان آباد-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (878, 3, N'شامکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (879, 3, N'تندک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (880, 3, N'روييني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (881, 3, N'اوندر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (882, 3, N'ريوش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (883, 3, N'دهنو-خراسان رضوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (884, 3, N'فدافن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (885, 3, N'خليل آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (886, 3, N'کندر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (887, 3, N'بندقرا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (888, 3, N'کاسف')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (889, 3, N'کبودان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (890, 3, N'شفيع اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (891, 3, N'رکن اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (892, 3, N'شهرآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (893, 3, N'انابد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (894, 3, N'درونه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (895, 3, N'يونسي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (896, 3, N'بيدخت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (897, 3, N'گيسوربالا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (898, 3, N'کاخک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (899, 3, N'زيبد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (900, 3, N'بجستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (901, 3, N'جزين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (902, 4, N'محمودآباد-مازندران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (903, 4, N'نور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (904, 4, N'نوشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (905, 4, N'سلمانشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (906, 4, N'تنکابن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (907, 4, N'رامسر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (908, 4, N'اميرکلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (909, 4, N'بابلسر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (910, 4, N'فريدونکنار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (911, 4, N'قائم شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (912, 4, N'جويبار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (913, 4, N'زير آب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (914, 4, N'پل سفيد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (915, 4, N'کياسر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (916, 4, N'نکا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (917, 4, N'بهشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (918, 4, N'گلوگاه-مازندران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (919, 4, N'دابودشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (920, 4, N'معلم کلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (921, 4, N'سرخرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (922, 4, N'وسطي کلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (923, 4, N'رينه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (924, 4, N'سوا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (925, 4, N'باييجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (926, 4, N'گزنک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (927, 4, N'ايزدشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (928, 4, N'چمستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (929, 4, N'بنفشه ده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (930, 4, N'رييس کلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (931, 4, N'اوز-مازندران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (932, 4, N'بلده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (933, 4, N'تاکر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (934, 4, N'گلندرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (935, 4, N'چلندر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (936, 4, N'صلاح الدين کلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (937, 4, N'نارنج بن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (938, 4, N'رويان-مازندران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (939, 4, N'کجور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (940, 4, N'پول')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (941, 4, N'لشکنار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (942, 4, N'هيچرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (943, 4, N'مرزن آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (944, 4, N'کرديچال')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (945, 4, N'کلاردشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (946, 4, N'کلنو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (947, 4, N'دلير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (948, 4, N'سياه بيشه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (949, 4, N'کلارآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (950, 4, N'عباس آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (951, 4, N'سرلنگا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (952, 4, N'کترا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (953, 4, N'گلعلي اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (954, 4, N'ميان کوه سادات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (955, 4, N'مران سه هزار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (956, 4, N'نشتارود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (957, 4, N'قلعه گردن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (958, 4, N'خرم آباد-مازندران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (959, 4, N'شيرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (960, 4, N'سليمان اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (961, 4, N'کشکو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (962, 4, N'لاک تراشان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (963, 4, N'سادات محله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (964, 4, N'کتالم وسادات شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (965, 4, N'اغوزکتي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (966, 4, N'جواهرده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (967, 4, N'جنت رودبار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (968, 4, N'تمل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (969, 4, N'خوشرودپي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (970, 4, N'اهنگرکلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (971, 4, N'گاوانکلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (972, 4, N'شورکش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (973, 4, N'اينج دان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (974, 4, N'عرب خيل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (975, 4, N'بهنمير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (976, 4, N'کاسگرمحله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (977, 4, N'کله بست')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (978, 4, N'بيشه سر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (979, 4, N'گتاب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (980, 4, N'درازکش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (981, 4, N'گردرودبار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (982, 4, N'مرزي کلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (983, 4, N'شهيداباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (984, 4, N'زرگرمحله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (985, 4, N'بالاجنيدلاک پل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (986, 4, N'خطيرکلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (987, 4, N'حاجي کلاصنم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (988, 4, N'واسکس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (989, 4, N'ريکنده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (990, 4, N'ارطه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (991, 4, N'کياکلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (992, 4, N'بالادسته رکن کنار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (993, 4, N'بيزکي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (994, 4, N'کوهي خيل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (995, 4, N'سنگتاب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (996, 4, N'رکابدارکلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (997, 4, N'شيرکلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (998, 4, N'آلاشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (999, 4, N'لفور (لفورک )')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1000, 4, N'اتو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1001, 4, N'شيرگاه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1002, 4, N'پالند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1003, 4, N'چرات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1004, 4, N'ده ميان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1005, 4, N'خشک دره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1006, 4, N'امافت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1007, 4, N'بالادواب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1008, 4, N'ورسک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1009, 4, N'کتي لته')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1010, 4, N'اروست')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1011, 4, N'فريم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1012, 4, N'سنگده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1013, 4, N'قاديکلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1014, 4, N'تاکام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1015, 4, N'پايين هولار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1016, 4, N'بالاهولار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1017, 4, N'اسبوکلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1018, 4, N'سورک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1019, 4, N'اسلام اباد-مازندران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1020, 4, N'شهرک صنعتي گهرباران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1021, 4, N'فرح اباد (خزراباد)')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1022, 4, N'دارابکلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1023, 4, N'ماچک پشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1024, 4, N'خورشيد (اماميه )')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1025, 4, N'زاغمرز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1026, 4, N'چلمردي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1027, 4, N'رستم کلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1028, 4, N'پايين زرندين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1029, 4, N'بادابسر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1030, 4, N'تيرتاش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1031, 4, N'خليل شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1032, 4, N'دامداري حسن ابوطالبي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1033, 4, N'بيشه بنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1034, 4, N'سفيدچاه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1035, 4, N'دامداري حاج عزيزمجريان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1036, 4, N'ميان دره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1037, 4, N'بندپي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1038, 8, N'گرمه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1039, 8, N'جاجرم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1040, 8, N'آشخانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1041, 8, N'شيروان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1042, 8, N'فاروج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1043, 8, N'اسفراين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1044, 8, N'درق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1045, 8, N'ايور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1046, 8, N'قاضي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1047, 8, N'شوقان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1048, 8, N'سنخواست')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1049, 8, N'پيش قلعه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1050, 8, N'راز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1051, 8, N'حصار گرمخان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1052, 8, N'لوجلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1053, 8, N'دوين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1054, 8, N'زيارت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1055, 8, N'رباط-خراسان شمالي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1056, 8, N'تيتکانلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1057, 8, N'خرق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1058, 8, N'صفي آباد-خراسان شمالي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1059, 8, N'رزق اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1060, 10, N'سربيشه-خراسان جنوبي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1061, 10, N'نهبندان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1062, 10, N'قاين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1063, 10, N'فردوس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1064, 10, N'بشرويه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1065, 10, N'طبس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1066, 10, N'مود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1067, 10, N'محمدشهر-خراسان جنوبي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1068, 10, N'خوسف')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1069, 10, N'طبس مسينا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1070, 10, N'اسديه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1071, 10, N'نيمبلوک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1072, 10, N'گزيک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1073, 10, N'قهستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1074, 10, N'شوسف')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1075, 10, N'آرين شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1076, 10, N'بيهود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1077, 10, N'خضري دشت بياض')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1078, 10, N'حاجي آباد-خراسان جنوبي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1079, 10, N'اسفدن-خراسان جنوبي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1080, 10, N'زهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1081, 10, N'اسلاميه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1082, 10, N'سرايان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1083, 10, N'آيسک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1084, 10, N'ارسک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1085, 10, N'سه قلعه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1086, 10, N'ديهوک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1087, 10, N'عشق آباد-خراسان جنوبي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1088, 10, N'گزو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1089, 2, N'سيلوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1090, 2, N'خوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1091, 2, N'مهاباد-آذربايجان غربي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1092, 2, N'قوشچي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1093, 2, N'نقده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1094, 2, N'اشنويه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1095, 2, N'پيرانشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1096, 2, N'جلديان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1097, 2, N'ايواوغلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1098, 2, N'ديزج ديز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1099, 2, N'فيرورق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1100, 2, N'ماکو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1101, 2, N'سلماس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1102, 2, N'تازه شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1103, 2, N'گوگ تپه-آذربايجان غربي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1104, 2, N'بوکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1105, 2, N'سردشت-آذربايجان غربي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1106, 2, N'مياندوآب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1107, 2, N'شاهيندژ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1108, 2, N'تکاب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1109, 2, N'باراندوز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1110, 2, N'ديزج دول')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1111, 2, N'مياوق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1112, 2, N'ايبلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1113, 2, N'دستجرد-آذربايجان غربي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1114, 2, N'نوشين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1115, 2, N'طلاتپه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1116, 2, N'سيلوانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1117, 2, N'راژان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1118, 2, N'هاشم اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1119, 2, N'ديزج-آذربايجان غربي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1120, 2, N'زيوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1121, 2, N'تويي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1122, 2, N'موانا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1123, 2, N'قره باغ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1124, 2, N'بهله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1125, 2, N'امام کندي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1126, 2, N'نازلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1127, 2, N'سرو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1128, 2, N'کانسپي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1129, 2, N'ممکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1130, 2, N'حسنلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1131, 2, N'کهريزعجم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1132, 2, N'محمديار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1133, 2, N'شيخ احمد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1134, 2, N'بيگم قلعه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1135, 2, N'راهدانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1136, 2, N'شاهوانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1137, 2, N'نالوس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1138, 2, N'ده شمس بزرگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1139, 2, N'گلاز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1140, 2, N'لولکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1141, 2, N'سياوان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1142, 2, N'کله کين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1143, 2, N'شين اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1144, 2, N'چيانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1145, 2, N'بيکوس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1146, 2, N'هنگ اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1147, 2, N'گردکشانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1148, 2, N'پسوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1149, 2, N'ريگ اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1150, 2, N'احمدغريب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1151, 2, N'سيه باز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1152, 2, N'بيله وار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1153, 2, N'ولديان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1154, 2, N'قوروق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1155, 2, N'هندوان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1156, 2, N'بدلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1157, 2, N'بلسورسفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1158, 2, N'زرآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1159, 2, N'استران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1160, 2, N'قطور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1161, 2, N'قره ضياءالدين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1162, 2, N'شيرين بلاغ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1163, 2, N'مراکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1164, 2, N'چورس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1165, 2, N'قورول عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1166, 2, N'بسطام-آذربايجان غربي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1167, 2, N'قره تپه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1168, 2, N'ريحانلوي عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1169, 2, N'زاويه سفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1170, 2, N'آواجيق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1171, 2, N'بازرگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1172, 2, N'قم قشلاق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1173, 2, N'يولاگلدي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1174, 2, N'سيه چشمه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1175, 2, N'قرنقو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1176, 2, N'شوط')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1177, 2, N'مرگنلر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1178, 2, N'پلدشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1179, 2, N'نازک عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1180, 2, N'حسن کندي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1181, 2, N'وردان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1182, 2, N'قره قشلاق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1183, 2, N'تمر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1184, 2, N'ابگرم-آذربايجان غربي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1185, 2, N'سرنق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1186, 2, N'چهريق عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1187, 2, N'داراب-آذربايجان غربي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1188, 2, N'دلزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1189, 2, N'اغ برزه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1190, 2, N'سنجي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1191, 2, N'خاتون باغ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1192, 2, N'حاجي حسن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1193, 2, N'سوگلي تپه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1194, 2, N'گليجه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1195, 2, N'حاجي کند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1196, 2, N'باغچه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1197, 2, N'خورخوره-آذربايجان غربي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1198, 2, N'خليفان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1199, 2, N'کاولان عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1200, 2, N'سياقول عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1201, 2, N'اگريقاش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1202, 2, N'اوزون دره عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1203, 2, N'يکشوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1204, 2, N'جوانمرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1205, 2, N'اختتر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1206, 2, N'سيمينه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1207, 2, N'رحيم خان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1208, 2, N'گل تپه قورميش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1209, 2, N'شلماش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1210, 2, N'اسلام اباد-آذربايجان غربي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1211, 2, N'بيوران سفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1212, 2, N'ميرآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1213, 2, N'زمزيران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1214, 2, N'ربط')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1215, 2, N'کشاورز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1216, 2, N'اقبال')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1217, 2, N'ملاشهاب الدين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1218, 2, N'للکلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1219, 2, N'بگتاش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1220, 2, N'چهار برج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1221, 2, N'گوگ تپه خالصه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1222, 2, N'تک اغاج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1223, 2, N'هاچاسو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1224, 2, N'هولاسو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1225, 2, N'قوزلوي افشار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1226, 2, N'محمودآباد-آذربايجان غربي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1227, 2, N'الي چين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1228, 2, N'حيدرباغي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1229, 2, N'حمزه قاسم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1230, 2, N'اوغول بيگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1231, 2, N'دورباش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1232, 2, N'اقابيگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1233, 2, N'احمدابادسفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1234, 2, N'باروق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1235, 11, N'رشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1236, 11, N'بندرانزلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1237, 11, N'لاهيجان-گيلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1238, 11, N'ابکنار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1239, 11, N'خمام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1240, 11, N'فومن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1241, 11, N'صومعه سرا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1242, 11, N'هشتپر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1243, 11, N'ماسال')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1244, 11, N'آستارا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1245, 11, N'سياهکل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1246, 11, N'آستانه اشرفيه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1247, 11, N'منجيل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1248, 11, N'رودبار-گيلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1249, 11, N'لنگرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1250, 11, N'رودسر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1251, 11, N'کلاچاي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1252, 11, N'کپورچال')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1253, 11, N'جيرهنده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1254, 11, N'ليچارکي حسن رود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1255, 11, N'سنگر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1256, 11, N'سراوان-گيلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1257, 11, N'خشکبيجار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1258, 11, N'لشت نشاء')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1259, 11, N'خواچکين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1260, 11, N'کوچصفهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1261, 11, N'بلسبنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1262, 11, N'چاپارخانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1263, 11, N'جيرکويه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1264, 11, N'ماکلوان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1265, 11, N'لولمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1266, 11, N'شفت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1267, 11, N'ملاسرا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1268, 11, N'چوبر-گيلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1269, 11, N'ماسوله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1270, 11, N'گشت-گيلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1271, 11, N'احمد سر گوراب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1272, 11, N'مرجقل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1273, 11, N'گوراب زرميخ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1274, 11, N'طاهرگوراب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1275, 11, N'ضيابر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1276, 11, N'مرکيه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1277, 11, N'هنده خاله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1278, 11, N'نوخاله اکبري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1279, 11, N'شيله وشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1280, 11, N'جوکندان بزرگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1281, 11, N'ليسار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1282, 11, N'بازارخطبه سرا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1283, 11, N'حويق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1284, 11, N'پلاسي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1285, 11, N'بازار جمعه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1286, 11, N'رضوانشهر-گيلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1287, 11, N'پره سر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1288, 11, N'پلنگ پاره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1289, 11, N'اسالم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1290, 11, N'شيخ محله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1291, 11, N'ويرموني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1292, 11, N'سيبلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1293, 11, N'لوندويل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1294, 11, N'مشند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1295, 11, N'کوته کومه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1296, 11, N'حيران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1297, 11, N'رودبنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1298, 11, N'پايين محله پاشاکي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1299, 11, N'گرماور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1300, 11, N'ليش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1301, 11, N'بارکوسرا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1302, 11, N'شيرين نسا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1303, 11, N'خرارود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1304, 11, N'ديلمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1305, 11, N'لسکوکلايه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1306, 11, N'کيسم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1307, 11, N'شيرکوه چهارده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1308, 11, N'دهشال')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1309, 11, N'کياشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1310, 11, N'دستک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1311, 11, N'پرگاپشت مهدي خاني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1312, 11, N'لوشان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1313, 11, N'بيورزين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1314, 11, N'جيرنده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1315, 11, N'بره سر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1316, 11, N'ويشان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1317, 11, N'کليشم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1318, 11, N'علي اباد-گيلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1319, 11, N'رستم آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1320, 11, N'توتکابن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1321, 11, N'کلشتر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1322, 11, N'اسکولک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1323, 11, N'کوکنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1324, 11, N'سلوش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1325, 11, N'چاف وچمخاله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1326, 11, N'شلمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1327, 11, N'کومله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1328, 11, N'ديوشل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1329, 11, N'پروش پايين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1330, 11, N'اطاقور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1331, 11, N'حسن سرا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1332, 11, N'طول لات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1333, 11, N'رانکوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1334, 11, N'چابکسر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1335, 11, N'جنگ سرا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1336, 11, N'واجارگاه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1337, 11, N'رحيم آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1338, 11, N'بلترک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1339, 11, N'املش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1340, 11, N'کجيد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1341, 11, N'گرمابدشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1342, 11, N'شوييل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1343, 11, N'پونل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1344, 12, N'اروندکنار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1345, 12, N'ملاثاني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1346, 12, N'بندرماهشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1347, 12, N'بهبهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1348, 12, N'آغاجاري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1349, 12, N'رامهرمز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1350, 12, N'ايذه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1351, 12, N'شادگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1352, 12, N'سوسنگرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1353, 12, N'شوشتر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1354, 12, N'دزفول')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1355, 12, N'شوش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1356, 12, N'انديمشک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1357, 12, N'مسجدسليمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1358, 12, N'الهائي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1359, 12, N'شيبان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1360, 12, N'ويس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1361, 12, N'فياضي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1362, 12, N'تنگ يک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1363, 12, N'چوئبده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1364, 12, N'نهرسليم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1365, 12, N'نهرابطر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1366, 12, N'عين دو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1367, 12, N'حميديه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1368, 12, N'ام الطمير (سيديوسف )')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1369, 12, N'کوت عبدالله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1370, 12, N'قلعه چنعان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1371, 12, N'کريت برومي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1372, 12, N'غيزانيه بزرگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1373, 12, N'چم کلگه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1374, 12, N'چمران-خوزستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1375, 12, N'بندرامام خميني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1376, 12, N'صالح شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1377, 12, N'اسياب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1378, 12, N'هنديجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1379, 12, N'تشان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1380, 12, N'گروه پدافندهوايي بهبها')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1381, 12, N'شاه غالب ده ابراهيم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1382, 12, N'کردستان بزرگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1383, 12, N'منصوريه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1384, 12, N'سردشت-خوزستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1385, 12, N'اميديه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1386, 12, N'ميانکوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1387, 12, N'زهره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1388, 12, N'رودزرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1389, 12, N'نفت سفيد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1390, 12, N'مشراگه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1391, 12, N'رامشير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1392, 12, N'جايزان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1393, 12, N'دره تونم نمي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1394, 12, N'ميداود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1395, 12, N'صيدون')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1396, 12, N'باغ ملک-خوزستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1397, 12, N'قلعه تل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1398, 12, N'چنارستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1399, 12, N'پشت پيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1400, 12, N'دهدز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1401, 12, N'خنافره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1402, 12, N'عبودي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1403, 12, N'دارخوين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1404, 12, N'درويشي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1405, 12, N'بوزي سيف')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1406, 12, N'مينوشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1407, 12, N'حفاري شرقي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1408, 12, N'بروايه يوسف')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1409, 12, N'کوت سيدنعيم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1410, 12, N'ابوحميظه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1411, 12, N'هويزه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1412, 12, N'يزدنو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1413, 12, N'رفيع')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1414, 12, N'بستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1415, 12, N'سيدعباس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1416, 12, N'سرداران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1417, 12, N'شرافت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1418, 12, N'گوريه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1419, 12, N'جنت مکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1420, 12, N'گتوند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1421, 12, N'ترکالکي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1422, 12, N'سماله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1423, 12, N'شهرک نورمحمدي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1424, 12, N'گاوميش اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1425, 12, N'عرب حسن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1426, 12, N'صفي آباد -خوزستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1427, 12, N'چغاميش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1428, 12, N'حمزه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1429, 12, N'شمس آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1430, 12, N'امام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1431, 12, N'سياه منصور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1432, 12, N'ميانرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1433, 12, N'چلون')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1434, 12, N'سالند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1435, 12, N'حر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1436, 12, N'شاوور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1437, 12, N'مزرعه يک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1438, 12, N'خسرجي راضي حمد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1439, 12, N'الوان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1440, 12, N'علمه تيمورابوذرغفاري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1441, 12, N'شهرک بهرام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1442, 12, N'فتح المبين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1443, 12, N'آزادي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1444, 12, N'شهرک انصار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1445, 12, N'خواجوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1446, 12, N'بيدروبه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1447, 12, N'حسينيه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1448, 12, N'کلگه دره دو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1449, 12, N'تله زنگ پايين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1450, 12, N'چم گلک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1451, 12, N'روستاي عنبر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1452, 12, N'لالي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1453, 12, N'دره بوري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1454, 12, N'هفتگل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1455, 12, N'کوشکک-خوزستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1456, 12, N'آبژدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1457, 12, N'قلعه خواجه-خوزستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1458, 12, N'گلگير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1459, 13, N'محمودآبادنمونه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1460, 13, N'بيدستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1461, 13, N'شريفيه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1462, 13, N'اقباليه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1463, 13, N'نصرت آباد-قزوين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1464, 13, N'الولک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1465, 13, N'کاکوهستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1466, 13, N'فلار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1467, 13, N'مينودشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1468, 13, N'زوارک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1469, 13, N'صمغ اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1470, 13, N'ناصراباد-قزوين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1471, 13, N'رشتقون')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1472, 13, N'قشلاق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1473, 13, N'خاکعلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1474, 13, N'شهرک صنعتي ليا (قديم )')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1475, 13, N'سگز آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1476, 13, N'عصمت اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1477, 13, N'خرم اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1478, 13, N'اسفرورين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1479, 13, N'شال')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1480, 13, N'دانسفهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1481, 13, N'کلنجين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1482, 13, N'آبگرم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1483, 13, N'استبلخ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1484, 13, N'ارداق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1485, 13, N'نيارج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1486, 13, N'حصاروليعصر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1487, 13, N'ماهين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1488, 13, N'سيردان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1489, 13, N'سياهپوش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1490, 13, N'نيارک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1491, 13, N'اقابابا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1492, 13, N'نرجه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1493, 13, N'خرمدشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1494, 13, N'ضياءآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1495, 13, N'حسين اباد-قزوين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1496, 13, N'رحيم اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1497, 13, N'مهرگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1498, 13, N'معلم کلايه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1499, 13, N'يحيي اباد-قزوين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1500, 13, N'نيکويه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1501, 13, N'رازميان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1502, 13, N'کوهين-قزوين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1503, 14, N'خيراباد-سمنان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1504, 14, N'ايستگاه ميان دره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1505, 14, N'اهوان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1506, 14, N'جام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1507, 14, N'دوزهير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1508, 14, N'معدن نمک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1509, 14, N'نظامي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1510, 14, N'اسداباد-سمنان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1511, 14, N'لاسجرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1512, 14, N'سيداباد-سمنان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1513, 14, N'عبدالله ابادپايين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1514, 14, N'بيابانک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1515, 14, N'مومن اباد-سمنان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1516, 14, N'درجزين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1517, 14, N'دربند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1518, 14, N'گل رودبار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1519, 14, N'ابگرم-سمنان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1520, 14, N'افتر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1521, 14, N'فولادمحله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1522, 14, N'ده صوفيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1523, 14, N'هيکو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1524, 14, N'چاشم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1525, 14, N'کردوان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1526, 14, N'مندولک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1527, 14, N'داوراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1528, 14, N'آرادان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1529, 14, N'بن کوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1530, 14, N'کهن آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1531, 14, N'حسين ابادکوروس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1532, 14, N'کرک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1533, 14, N'گلستانک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1534, 14, N'لجران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1535, 14, N'جودانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1536, 14, N'ابراهيم اباد-سمنان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1537, 14, N'بکران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1538, 14, N'کرداباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1539, 14, N'نردين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1540, 14, N'سوداغلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1541, 14, N'فرومد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1542, 14, N'ابرسيج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1543, 14, N'ميغان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1544, 14, N'قلعه نوخرقان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1545, 14, N'چهلدخترپادگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1546, 14, N'کلاته خيج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1547, 14, N'نگارمن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1548, 14, N'دهملا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1549, 14, N'رويان-سمنان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1550, 14, N'بدشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1551, 14, N'سطوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1552, 14, N'طرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1553, 14, N'مغان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1554, 14, N'گيور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1555, 14, N'دستجرد-سمنان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1556, 14, N'مسيح اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1557, 14, N'احمداباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1558, 14, N'زمان اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1559, 14, N'سلمرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1560, 14, N'جزن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1561, 14, N'برم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1562, 14, N'محمداباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1563, 14, N'معصوم اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1564, 14, N'فرات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1565, 14, N'عليان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1566, 14, N'عمروان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1567, 14, N'قوشه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1568, 14, N'دروار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1569, 14, N'استانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1570, 14, N'ديباج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1571, 14, N'طرزه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1572, 14, N'مهماندوست')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1573, 14, N'کلاته ملا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1574, 14, N'قدرت اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1575, 15, N'قنوات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1576, 15, N'دستجرد-قم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1577, 15, N'اميرابادگنجي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1578, 15, N'قمرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1579, 15, N'کهک-قم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1580, 15, N'قلعه چم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1581, 15, N'قاهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1582, 15, N'جعفريه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1583, 15, N'جنداب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1584, 15, N'سلفچگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1585, 16, N'پرندک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1586, 16, N'محلات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1587, 16, N'دليجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1588, 16, N'کرهرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1589, 16, N'خنداب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1590, 16, N'کميجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1591, 16, N'شازند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1592, 16, N'آستانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1593, 16, N'خمين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1594, 16, N'رباطمراد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1595, 16, N'غرق آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1596, 16, N'مامونيه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1597, 16, N'تفرش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1598, 16, N'آشتيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1599, 16, N'شهرجديدمهاجران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1600, 16, N'سلطان اباد-مركزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1601, 16, N'اصفهانک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1602, 16, N'حسين اباد-مركزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1603, 16, N'خشکرود-مركزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1604, 16, N'حکيم اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1605, 16, N'يحيي اباد-مركزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1606, 16, N'صدراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1607, 16, N'نيمور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1608, 16, N'نخجيروان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1609, 16, N'باقراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1610, 16, N'بزيجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1611, 16, N'عيسي اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1612, 16, N'خورهه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1613, 16, N'نراق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1614, 16, N'ساروق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1615, 16, N'داودآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1616, 16, N'کارچان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1617, 16, N'جاورسيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1618, 16, N'ادشته')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1619, 16, N'استوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1620, 16, N'سنجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1621, 16, N'اناج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1622, 16, N'وفس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1623, 16, N'خسروبيگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1624, 16, N'ميلاجرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1625, 16, N'سمقاور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1626, 16, N'هزاوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1627, 16, N'قدمگاه-مركزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1628, 16, N'هفته')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1629, 16, N'لنجرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1630, 16, N'توره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1631, 16, N'کزاز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1632, 16, N'کتيران بالا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1633, 16, N'نهرميان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1634, 16, N'سرسختي بالا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1635, 16, N'لوزدرعليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1636, 16, N'هندودر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1637, 16, N'تواندشت عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1638, 16, N'مالمير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1639, 16, N'چهارچريک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1640, 16, N'چهارچشمه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1641, 16, N'لکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1642, 16, N'قورچي باشي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1643, 16, N'ورچه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1644, 16, N'فرفهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1645, 16, N'امامزاده ورچه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1646, 16, N'رباطکفسان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1647, 16, N'ريحان عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1648, 16, N'جزنق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1649, 16, N'خوراوند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1650, 16, N'ميشيجان عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1651, 16, N'گلدشت-مركزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1652, 16, N'دهنو-مركزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1653, 16, N'نوبران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1654, 16, N'يل اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1655, 16, N'رازقان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1656, 16, N'الوير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1657, 16, N'دوزج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1658, 16, N'عليشار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1659, 16, N'بالقلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1660, 16, N'زاويه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1661, 16, N'چمران-مركزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1662, 16, N'قاقان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1663, 16, N'سامان-مركزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1664, 16, N'دخان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1665, 16, N'مراغه-مركزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1666, 16, N'فرمهين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1667, 16, N'شهراب-مركزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1668, 16, N'زاغر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1669, 16, N'کهک-مركزي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1670, 16, N'فشک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1671, 16, N'اهنگران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1672, 16, N'مزرعه نو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1673, 16, N'صالح اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1674, 16, N'سياوشان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1675, 16, N'اهو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1676, 17, N'زرين آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1677, 17, N'ماهنشان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1678, 17, N'سلطانيه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1679, 17, N'ابهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1680, 17, N'خرمدره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1681, 17, N'قيدار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1682, 17, N'آب بر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1683, 17, N'همايون')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1684, 17, N'بوغداکندي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1685, 17, N'اژدهاتو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1686, 17, N'اسفجين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1687, 17, N'ارمغانخانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1688, 17, N'قبله بلاغي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1689, 17, N'پري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1690, 17, N'اندابادعليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1691, 17, N'قره گل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1692, 17, N'نيک پي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1693, 17, N'دندي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1694, 17, N'سونتو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1695, 17, N'قلتوق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1696, 17, N'گوزلدره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1697, 17, N'سنبل اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1698, 17, N'درسجين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1699, 17, N'دولت اباد-زنجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1700, 17, N'کينه ورس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1701, 17, N'هيدج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1702, 17, N'صائين قلعه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1703, 17, N'اقبلاغ سفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1704, 17, N'سهرورد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1705, 17, N'کرسف')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1706, 17, N'سجاس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1707, 17, N'محموداباد-زنجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1708, 17, N'باش قشلاق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1709, 17, N'گرماب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1710, 17, N'زرين رود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1711, 17, N'کهلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1712, 17, N'گيلوان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1713, 17, N'دستجرده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1714, 17, N'سعيداباد-زنجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1715, 17, N'چورزق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1716, 17, N'حلب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1717, 17, N'درام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1718, 18, N'بندر گز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1719, 18, N'کردکوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1720, 18, N'بندرترکمن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1721, 18, N'آق قلا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1722, 18, N'علي آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1723, 18, N'راميان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1724, 18, N'آزاد شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1725, 18, N'گنبد کاووس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1726, 18, N'مينو دشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1727, 18, N'کلاله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1728, 18, N'نوکنده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1729, 18, N'مراوه تپه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1730, 18, N'گميش تپه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1731, 18, N'سيمين شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1732, 18, N'جلين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1733, 18, N'سرخنکلاته')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1734, 18, N'تقي اباد-گلستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1735, 18, N'انبار آلوم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1736, 18, N'فاضل آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1737, 18, N'حاجيکلاته')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1738, 18, N'خان ببين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1739, 18, N'دلند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1740, 18, N'نگين شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1741, 18, N'نوده خاندوز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1742, 18, N'تاتارعليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1743, 18, N'اينچه برون')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1744, 18, N'کرند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1745, 18, N'گاليکش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1746, 18, N'عزيزاباد-گلستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1747, 19, N'نمين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1748, 19, N'نير-اردبيل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1749, 19, N'گرمي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1750, 19, N'مشگين شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1751, 19, N'بيله سوار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1752, 19, N'خلخال')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1753, 19, N'پارس آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1754, 19, N'آبي بيگلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1755, 19, N'ننه کران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1756, 19, N'عنبران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1757, 19, N'گرده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1758, 19, N'ثمرين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1759, 19, N'ارديموسي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1760, 19, N'سرعين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1761, 19, N'کورائيم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1762, 19, N'اسلام اباد-اردبيل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1763, 19, N'مهماندوست عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1764, 19, N'هير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1765, 19, N'بقراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1766, 19, N'بودالالو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1767, 19, N'اراللوي بزرگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1768, 19, N'ديزج-اردبيل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1769, 19, N'حمزه خانلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1770, 19, N'زهرا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1771, 19, N'اني عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1772, 19, N'قاسم کندي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1773, 19, N'تازه کندانگوت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1774, 19, N'قره اغاج پايين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1775, 19, N'پريخان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1776, 19, N'قصابه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1777, 19, N'فخرآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1778, 19, N'لاهرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1779, 19, N'رضي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1780, 19, N'قوشه سفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1781, 19, N'مرادلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1782, 19, N'گنجوبه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1783, 19, N'گوگ تپه-اردبيل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1784, 19, N'انجيرلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1785, 19, N'جعفر آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1786, 19, N'قشلاق اغداش کلام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1787, 19, N'خورخورسفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1788, 19, N'شورگل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1789, 19, N'نظرعلي بلاغي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1790, 19, N'لنبر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1791, 19, N'فيروزاباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1792, 19, N'گيوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1793, 19, N'خلفلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1794, 19, N'هشتجين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1795, 19, N'برندق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1796, 19, N'کلور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1797, 19, N'تازه کندجديد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1798, 19, N'گوشلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1799, 19, N'اق قباق عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1800, 19, N'شهرک غفاري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1801, 19, N'اصلاندوز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1802, 19, N'بران عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1803, 20, N'بهار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1804, 20, N'اسدآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1805, 20, N'کبودرآهنگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1806, 20, N'فامنين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1807, 20, N'ملاير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1808, 20, N'تويسرکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1809, 20, N'نهاوند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1810, 20, N'مريانج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1811, 20, N'جورقان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1812, 20, N'لالجين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1813, 20, N'ديناراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1814, 20, N'همه کسي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1815, 20, N'صالح آباد-همدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1816, 20, N'پرلوک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1817, 20, N'حسين ابادبهارعاشوري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1818, 20, N'مهاجران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1819, 20, N'ويرايي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1820, 20, N'جنت اباد-همدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1821, 20, N'موسي اباد-همدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1822, 20, N'چنارسفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1823, 20, N'چنارعليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1824, 20, N'آجين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1825, 20, N'طويلان سفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1826, 20, N'کوريجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1827, 20, N'کوهين-همدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1828, 20, N'قهوردسفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1829, 20, N'اکنلو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1830, 20, N'شيرين سو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1831, 20, N'گل تپه-همدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1832, 20, N'داق داق اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1833, 20, N'قهاوند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1834, 20, N'تجرک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1835, 20, N'کوزره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1836, 20, N'چانگرين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1837, 20, N'دمق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1838, 20, N'رزن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1839, 20, N'قروه درجزين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1840, 20, N'ازناو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1841, 20, N'جوزان-همدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1842, 20, N'زنگنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1843, 20, N'سامن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1844, 20, N'اورزمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1845, 20, N'جوکار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1846, 20, N'اسلام اباد-همدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1847, 20, N'جعفريه (قلعه جعفربيک )')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1848, 20, N'سرکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1849, 20, N'ميانده-همدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1850, 20, N'فرسفج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1851, 20, N'ولاشجرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1852, 20, N'اشتران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1853, 20, N'باباپير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1854, 20, N'جهان اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1855, 20, N'باباقاسم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1856, 20, N'بابارستم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1857, 20, N'برزول')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1858, 20, N'گيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1859, 20, N'دهفول')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1860, 20, N'فيروزان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1861, 20, N'شهرک صنعتي بوعلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1862, 20, N'پايگاه نوژه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1863, 20, N'عليصدر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1864, 20, N'ازندريان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1865, 20, N'گنبد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1866, 20, N'پادگان قهرمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1867, 21, N'کامياران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1868, 21, N'ديواندره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1869, 21, N'بيجار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1870, 21, N'قروه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1871, 21, N'مريوان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1872, 21, N'سقز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1873, 21, N'بانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1874, 21, N'شويشه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1875, 21, N'شاهيني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1876, 21, N'طاي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1877, 21, N'گازرخاني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1878, 21, N'نشورسفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1879, 21, N'شيروانه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1880, 21, N'خامسان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1881, 21, N'موچش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1882, 21, N'شريف اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1883, 21, N'کوله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1884, 21, N'هزارکانيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1885, 21, N'زرينه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1886, 21, N'گورباباعلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1887, 21, N'گاوشله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1888, 21, N'خرکه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1889, 21, N'ياسوکند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1890, 21, N'توپ اغاج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1891, 21, N'اق بلاغ طغامين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1892, 21, N'بابارشاني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1893, 21, N'خسرواباد-كردستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1894, 21, N'جعفراباد-كردستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1895, 21, N'دلبران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1896, 21, N'دزج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1897, 21, N'کاني گنجي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1898, 21, N'بلبان آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1899, 21, N'دهگلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1900, 21, N'قوريچاي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1901, 21, N'سريش آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1902, 21, N'کاني دينار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1903, 21, N'ني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1904, 21, N'برده رشه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1905, 21, N'چناره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1906, 21, N'پيرخضران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1907, 21, N'بيساران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1908, 21, N'سروآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1909, 21, N'اورامان تخت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1910, 21, N'سرا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1911, 21, N'گل تپه-كردستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1912, 21, N'تيلکو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1913, 21, N'صاحب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1914, 21, N'خورخوره-كردستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1915, 21, N'کسنزان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1916, 21, N'ميرده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1917, 21, N'ننور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1918, 21, N'بوئين سفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1919, 21, N'آرمرده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1920, 21, N'بوالحسن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1921, 21, N'کاني سور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1922, 21, N'کوخان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1923, 21, N'شوي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1924, 22, N'هرسين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1925, 22, N'کنگاور-كرمانشاه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1926, 22, N'سنقر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1927, 22, N'اسلام آبادغرب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1928, 22, N'سرپل ذهاب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1929, 22, N'قصرشيرين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1930, 22, N'پاوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1931, 22, N'رباط-كرمانشاه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1932, 22, N'هفت اشيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1933, 22, N'هلشي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1934, 22, N'دوردشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1935, 22, N'سنقراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1936, 22, N'بيستون')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1937, 22, N'جعفراباد-كرمانشاه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1938, 22, N'مرزباني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1939, 22, N'فش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1940, 22, N'فرامان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1941, 22, N'سلطان اباد-كرمانشاه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1942, 22, N'صحنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1943, 22, N'قزوينه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1944, 22, N'دهلقين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1945, 22, N'درکه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1946, 22, N'باوله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1947, 22, N'گردکانه عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1948, 22, N'اگاه عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1949, 22, N'سطر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1950, 22, N'کيوه نان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1951, 22, N'ميان راهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1952, 22, N'کرکسار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1953, 22, N'کندوله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1954, 22, N'زاوله عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1955, 22, N'حميل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1956, 22, N'ريجاب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1957, 22, N'کرندغرب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1958, 22, N'گهواره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1959, 22, N'کوزران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1960, 22, N'قلعه شيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1961, 22, N'حسن اباد-كرمانشاه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1962, 22, N'سراب ذهاب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1963, 22, N'ترک ويس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1964, 22, N'ازگله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1965, 22, N'تازه آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1966, 22, N'نسارديره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1967, 22, N'سرمست')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1968, 22, N'تپه رش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1969, 22, N'خسروي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1970, 22, N'سومار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1971, 22, N'گيلانغرب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1972, 22, N'قيلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1973, 22, N'شاهو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1974, 22, N'باينگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1975, 22, N'بانوره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1976, 22, N'نوسود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1977, 22, N'نودشه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1978, 22, N'روانسر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1979, 22, N'دولت اباد-كرمانشاه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1980, 22, N'جوانرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1981, 22, N'ميراباد-كرمانشاه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1982, 23, N'نورآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1983, 23, N'کوهدشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1984, 23, N'پلدختر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1985, 23, N'اليگودرز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1986, 23, N'ازنا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1987, 23, N'دورود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1988, 23, N'الشتر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1989, 23, N'ماسور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1990, 23, N'بيرانوند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1991, 23, N'برخوردار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1992, 23, N'فرهاداباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1993, 23, N'دم باغ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1994, 23, N'کهريزوروشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1995, 23, N'چشمه کيزاب عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1996, 23, N'هفت چشمه-لرستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1997, 23, N'تقي اباد-لرستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1998, 23, N'خوشناموند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (1999, 23, N'اشتره گل گل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2000, 23, N'چقابل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2001, 23, N'سوري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2002, 23, N'کوناني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2003, 23, N'گراب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2004, 23, N'درب گنبد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2005, 23, N'پاعلم (پل تنگ )')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2006, 23, N'واشيان نصيرتپه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2007, 23, N'چمشک زيرتنگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2008, 23, N'افرينه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2009, 23, N'معمولان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2010, 23, N'ويسيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2011, 23, N'ميان تاگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2012, 23, N'پل شوراب پايين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2013, 23, N'شاهپوراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2014, 23, N'چمن سلطان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2015, 23, N'کيزاندره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2016, 23, N'قلعه بزنويد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2017, 23, N'شول آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2018, 23, N'حيه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2019, 23, N'مرگ سر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2020, 23, N'مومن آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2021, 23, N'رازان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2022, 23, N'سياه گوشي (پل هرو)')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2023, 23, N'زاغه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2024, 23, N'سرابدوره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2025, 23, N'چاه ذوالفقار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2026, 23, N'چم پلک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2027, 23, N'ژان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2028, 23, N'کاغه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2029, 23, N'چالانچولان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2030, 23, N'سپيد دشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2031, 23, N'چم سنگر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2032, 23, N'ايستگاه تنگ هفت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2033, 23, N'مکينه حکومتي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2034, 23, N'سراب سياهپوش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2035, 23, N'ده رحم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2036, 23, N'فيروز آباد-لرستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2037, 23, N'اشترينان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2038, 23, N'بنديزه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2039, 23, N'دره گرگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2040, 24, N'بوشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2041, 24, N'بندرگناوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2042, 24, N'خورموج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2043, 24, N'اهرم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2044, 24, N'برازجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2045, 24, N'نخل تقي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2046, 24, N'بندر ريگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2047, 24, N'چهارروستايي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2048, 24, N'شول')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2049, 24, N'بندر ديلم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2050, 24, N'امام حسن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2051, 24, N'چغادک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2052, 24, N'سيراف')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2053, 24, N'عسلويه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2054, 24, N'بادوله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2055, 24, N'شنبه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2056, 24, N'کاکي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2057, 24, N'خارک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2058, 24, N'دلوار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2059, 24, N'بنه گز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2060, 24, N'اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2061, 24, N'بردخون')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2062, 24, N'بردستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2063, 24, N'بندردير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2064, 24, N'آبدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2065, 24, N'انارستان-بوشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2066, 24, N'ريز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2067, 24, N'بنک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2068, 24, N'بندرکنگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2069, 24, N'جم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2070, 24, N'ابگرمک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2071, 24, N'دالکي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2072, 24, N'شبانکاره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2073, 24, N'آبپخش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2074, 24, N'سعدآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2075, 24, N'وحدتيه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2076, 24, N'تنگ ارم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2077, 24, N'کلمه-بوشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2078, 25, N'ماهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2079, 25, N'گلباف')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2080, 25, N'راور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2081, 25, N'بم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2082, 25, N'بروات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2083, 25, N'راين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2084, 25, N'محمدآباد-كرمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2085, 25, N'سرچشمه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2086, 25, N'انار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2087, 25, N'شهربابک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2088, 25, N'زرند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2089, 25, N'کيانشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2090, 25, N'کوهبنان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2091, 25, N'چترود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2092, 25, N'پاريز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2093, 25, N'بردسير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2094, 25, N'بافت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2095, 25, N'جيرفت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2096, 25, N'عنبرآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2097, 25, N'کهنوج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2098, 25, N'منوجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2099, 25, N'ده بالا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2100, 25, N'جوپار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2101, 25, N'باغين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2102, 25, N'اختيارآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2103, 25, N'زنگي آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2104, 25, N'جوشان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2105, 25, N'اندوهجرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2106, 25, N'شهداد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2107, 25, N'کشيت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2108, 25, N'فيض اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2109, 25, N'دريجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2110, 25, N'نرماشير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2111, 25, N'فهرج-كرمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2112, 25, N'برج معاز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2113, 25, N'نظام شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2114, 25, N'خانه خاتون')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2115, 25, N'ابارق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2116, 25, N'گروه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2117, 25, N'گزک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2118, 25, N'محي آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2119, 25, N'تهرود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2120, 25, N'ميرابادارجمند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2121, 25, N'داوران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2122, 25, N'خنامان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2123, 25, N'کبوترخان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2124, 25, N'هرمزاباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2125, 25, N'کشکوئيه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2126, 25, N'گلشن-كرمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2127, 25, N'صفائيه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2128, 25, N'امين شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2129, 25, N'بهرمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2130, 25, N'جواديه الهيه نوق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2131, 25, N'خاتون آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2132, 25, N'محمدابادبرفه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2133, 25, N'خورسند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2134, 25, N'خبر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2135, 25, N'کمسرخ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2136, 25, N'جوزم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2137, 25, N'دهج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2138, 25, N'دشت خاک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2139, 25, N'حتکن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2140, 25, N'ريحان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2141, 25, N'جرجافک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2142, 25, N'يزدان شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2143, 25, N'شعبجره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2144, 25, N'سيريز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2145, 25, N'خانوک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2146, 25, N'جور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2147, 25, N'هوتک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2148, 25, N'کاظم آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2149, 25, N'هجدک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2150, 25, N'حرجند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2151, 25, N'نجف شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2152, 25, N'بلورد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2153, 25, N'ملک اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2154, 25, N'عماداباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2155, 25, N'زيدآباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2156, 25, N'هماشهر-كرمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2157, 25, N'نگار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2158, 25, N'گلزار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2159, 25, N'لاله زار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2160, 25, N'قلعه عسکر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2161, 25, N'مومن اباد-كرمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2162, 25, N'چناربرين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2163, 25, N'کمال اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2164, 25, N'اميراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2165, 25, N'بزنجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2166, 25, N'رابر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2167, 25, N'پتکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2168, 25, N'ارزوئیه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2169, 25, N'جبالبارز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2170, 25, N'درب بهشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2171, 25, N'رضي ابادبالا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2172, 25, N'ميجان عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2173, 25, N'مردهک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2174, 25, N'دوساري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2175, 25, N'حسين ابادجديد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2176, 25, N'بلوک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2177, 25, N'رودبار-كرمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2178, 25, N'قلعه گنج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2179, 25, N'نودژ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2180, 25, N'فارياب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2181, 25, N'سرخ قلعه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2182, 25, N'خيراباد-كرمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2183, 26, N'خمير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2184, 26, N'کيش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2185, 26, N'قشم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2186, 26, N'بستک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2187, 26, N'بندرلنگه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2188, 26, N'ميناب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2189, 26, N'دهبارز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2190, 26, N'پشته ايسين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2191, 26, N'پل شرقي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2192, 26, N'فين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2193, 26, N'سياهو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2194, 26, N'سرگز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2195, 26, N'فارغان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2196, 26, N'باغات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2197, 26, N'حاجي آباد-هرمزگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2198, 26, N'ابگرم خورگو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2199, 26, N'قلعه قاضي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2200, 26, N'تخت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2201, 26, N'حسن لنگي پايين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2202, 26, N'گروک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2203, 26, N'سيريک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2204, 26, N'گونمردي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2205, 26, N'گوهرت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2206, 26, N'درگهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2207, 26, N'سوزا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2208, 26, N'هرمز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2209, 26, N'جزيره لارک شهري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2210, 26, N'هنگام جديد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2211, 26, N'جزيره سيري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2212, 26, N'ابوموسي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2213, 26, N'جناح')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2214, 26, N'پدل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2215, 26, N'کنگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2216, 26, N'دژگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2217, 26, N'رويدر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2218, 26, N'دهنگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2219, 26, N'کمشک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2220, 26, N'کوشکنار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2221, 26, N'گزير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2222, 26, N'بندرمغويه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2223, 26, N'چارک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2224, 26, N'دشتي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2225, 26, N'پارسيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2226, 26, N'جزيره لاوان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2227, 26, N'بندرجاسک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2228, 26, N'بندر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2229, 26, N'سندرک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2230, 26, N'درپهن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2231, 26, N'کلورجکدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2232, 26, N'گوهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2233, 26, N'سرددشت بشاگرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2234, 26, N'بيکاه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2235, 26, N'جغين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2236, 26, N'زيارت علي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2237, 26, N'ماشنگي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2238, 26, N'گوربند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2239, 26, N'تياب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2240, 26, N'بندرکهنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2241, 26, N'هشتبندي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2242, 27, N'فرخ شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2243, 27, N'دزک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2244, 27, N'هفشجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2245, 27, N'هاروني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2246, 27, N'سامان-چهارمحال و بختياري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2247, 27, N'فارسان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2248, 27, N'بروجن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2249, 27, N'اردل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2250, 27, N'لردگان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2251, 27, N'کيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2252, 27, N'طاقانک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2253, 27, N'خراجي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2254, 27, N'دستناء')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2255, 27, N'شلمزار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2256, 27, N'گهرو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2257, 27, N'سورشجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2258, 27, N'مرغملک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2259, 27, N'سودجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2260, 27, N'نافچ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2261, 27, N'وردنجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2262, 27, N'بن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2263, 27, N'پردنجان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2264, 27, N'باباحيدر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2265, 27, N'چلگرد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2266, 27, N'شهرياري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2267, 27, N'جونقان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2268, 27, N'نقنه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2269, 27, N'فرادنبه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2270, 27, N'سفيد دشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2271, 27, N'بلداجي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2272, 27, N'اورگان-چهارمحال و بختياري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2273, 27, N'گندمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2274, 27, N'امام قيس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2275, 27, N'ناغان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2276, 27, N'گل سفيد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2277, 27, N'چوله دان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2278, 27, N'دشتک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2279, 27, N'آلوني')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2280, 27, N'مال خليفه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2281, 27, N'چمن بيد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2282, 27, N'سردشت-چهارمحال و بختياري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2283, 27, N'منج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2284, 28, N'ابرکوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2285, 28, N'اردکان-يزد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2286, 28, N'ميبد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2287, 28, N'بافق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2288, 28, N'مهريز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2289, 28, N'تفت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2290, 28, N'فراغه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2291, 28, N'مهردشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2292, 28, N'اسفنداباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2293, 28, N'اشکذر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2294, 28, N'زارچ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2295, 28, N'شاهديه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2296, 28, N'فهرج-يزد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2297, 28, N'خضر آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2298, 28, N'ندوشن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2299, 28, N'حميديا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2300, 28, N'احمد آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2301, 28, N'عقدا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2302, 28, N'انارستان-يزد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2303, 28, N'زرين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2304, 28, N'بفروئيه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2305, 28, N'اسفيج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2306, 28, N'مبارکه-يزد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2307, 28, N'بهاباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2308, 28, N'کوشک-يزد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2309, 28, N'بنستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2310, 28, N'تنگ چنار (چنار)')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2311, 28, N'ارنان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2312, 28, N'بهادران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2313, 28, N'مروست')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2314, 28, N'هرات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2315, 28, N'فتح اباد-يزد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2316, 28, N'ناحيه صنعتي پيشکوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2317, 28, N'نصراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2318, 28, N'علي اباد-يزد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2319, 28, N'نير-يزد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2320, 28, N'ناحيه صنعتي گاريزات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2321, 28, N'دهشير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2322, 29, N'نصرت آباد-سيستان و بلوچستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2323, 29, N'ميرجاوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2324, 29, N'زابل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2325, 29, N'زهک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2326, 29, N'خواجه احمد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2327, 29, N'خاش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2328, 29, N'سرباز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2329, 29, N'بمپور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2330, 29, N'سراوان-سيستان و بلوچستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2331, 29, N'سوران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2332, 29, N'چابهار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2333, 29, N'کنارک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2334, 29, N'نيکشهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2335, 29, N'حرمک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2336, 29, N'گلوگاه-سيستان و بلوچستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2337, 29, N'انده قديم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2338, 29, N'لاديزعليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2339, 29, N'هيرمند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2340, 29, N'سيادک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2341, 29, N'خمک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2342, 29, N'تخت عدالت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2343, 29, N'برجميرگل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2344, 29, N'جهان ابادعليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2345, 29, N'اديمي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2346, 29, N'علي اکبر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2347, 29, N'تيموراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2348, 29, N'دولت اباد-سيستان و بلوچستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2349, 29, N'لوتک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2350, 29, N'سکوهه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2351, 29, N'محمد آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2352, 29, N'بنجار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2353, 29, N'جزينک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2354, 29, N'قلعه نو-سيستان و بلوچستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2355, 29, N'شهرک محمدشاه کرم')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2356, 29, N'ژاله اي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2357, 29, N'کرباسک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2358, 29, N'نوک اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2359, 29, N'نوراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2360, 29, N'کارواندر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2361, 29, N'ناصراباد-سيستان و بلوچستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2362, 29, N'بالاقلعه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2363, 29, N'گمن')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2364, 29, N'زيرکدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2365, 29, N'بيت اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2366, 29, N'گوهرکوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2367, 29, N'ده پابيد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2368, 29, N'نازيل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2369, 29, N'کوشه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2370, 29, N'سنگان-سيستان و بلوچستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2371, 29, N'افضل اباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2372, 29, N'چانف')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2373, 29, N'اسماعيل کلگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2374, 29, N'پارود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2375, 29, N'راسک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2376, 29, N'پيشين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2377, 29, N'ايرافشان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2378, 29, N'سرداب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2379, 29, N'محمدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2380, 29, N'اسپکه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2381, 29, N'پيپ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2382, 29, N'بنت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2383, 29, N'فنوج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2384, 29, N'گلمورتي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2385, 29, N'هوديان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2386, 29, N'بزمان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2387, 29, N'کوشکوک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2388, 29, N'محمدي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2389, 29, N'سردک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2390, 29, N'جالق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2391, 29, N'سيرکان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2392, 29, N'اسفندک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2393, 29, N'کوهک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2394, 29, N'گشت-سيستان و بلوچستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2395, 29, N'پسکوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2396, 29, N'مهرستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2397, 29, N'هيدوچ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2398, 29, N'طيس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2399, 29, N'تلنگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2400, 29, N'پلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2401, 29, N'نگور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2402, 29, N'باهوکلات')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2403, 29, N'پسابندر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2404, 29, N'پيرسهراب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2405, 29, N'شهدادکهير')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2406, 29, N'زراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2407, 29, N'مسکوتان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2408, 29, N'کتيج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2409, 29, N'دستگرد-سيستان و بلوچستان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2410, 29, N'محنت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2411, 29, N'چاهان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2412, 29, N'هيچان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2413, 29, N'قصرقند')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2414, 29, N'شگيم بالا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2415, 29, N'کشيک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2416, 29, N'ساربوک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2417, 30, N'ايلام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2418, 30, N'ايوان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2419, 30, N'سرآبله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2420, 30, N'دره شهر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2421, 30, N'آبدانان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2422, 30, N'دهلران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2423, 30, N'مهران')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2424, 30, N'چنارباشي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2425, 30, N'بيشه دراز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2426, 30, N'چشمه کبود')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2427, 30, N'چوار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2428, 30, N'بانويزه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2429, 30, N'چمن سيدمحمد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2430, 30, N'هفت چشمه-ايلام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2431, 30, N'شورابه ملک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2432, 30, N'کلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2433, 30, N'زرنه-ايلام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2434, 30, N'شباب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2435, 30, N'توحيد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2436, 30, N'بلاوه تره سفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2437, 30, N'لومار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2438, 30, N'آسمان آباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2439, 30, N'سراب کارزان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2440, 30, N'شهرک سرتنگ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2441, 30, N'علي اباد-ايلام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2442, 30, N'ماژين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2443, 30, N'ارمو')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2444, 30, N'چشمه شيرين')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2445, 30, N'بدره')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2446, 30, N'شهرک وليعصر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2447, 30, N'گنداب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2448, 30, N'ژيور')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2449, 30, N'سراب باغ')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2450, 30, N'مورموري')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2451, 30, N'سياه گل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2452, 30, N'اب انار')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2453, 30, N'چم هندي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2454, 30, N'موسيان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2455, 30, N'گولاب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2456, 30, N'ميمه-ايلام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2457, 30, N'پهله')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2458, 30, N'عين خوش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2459, 30, N'دشت عباس')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2460, 30, N'شهرک اسلاميه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2461, 30, N'صالح آباد-ايلام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2462, 30, N'دلگشا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2463, 30, N'ارکواز')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2464, 30, N'مهر-ايلام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2465, 30, N'دول کبودخوشادول')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2466, 30, N'پارياب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2467, 31, N'ياسوج')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2468, 31, N'دهدشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2469, 31, N'دوگنبدان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2470, 31, N'سوق')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2471, 31, N'لنده')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2472, 31, N'ليکک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2473, 31, N'چرام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2474, 31, N'ديشموک')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2475, 31, N'قلعه رييسي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2476, 31, N'قلعه دختر')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2477, 31, N'باباکلان')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2478, 31, N'مظفراباد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2479, 31, N'ديل')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2480, 31, N'شاه بهرام')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2481, 31, N'چاه تلخاب عليا')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2482, 31, N'باشت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2483, 31, N'سربيشه-كهگيلويه و بويراحمد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2484, 31, N'مادوان-كهگيلويه و بويراحمد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2485, 31, N'چيتاب')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2486, 31, N'گراب سفلي')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2487, 31, N'مارگون')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2488, 31, N'ميمند-كهگيلويه و بويراحمد')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2489, 31, N'پاتاوه')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2490, 31, N'سي سخت')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2491, 1, N'سسیش')
GO
INSERT [dbo].[Cities] ([Id], [ProvinceId], [Name]) VALUES (2492, 26, N'ایسین')
