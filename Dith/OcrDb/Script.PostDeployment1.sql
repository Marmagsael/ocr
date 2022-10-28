
if not exists (select 1 from dbo.[Country] ) 
begin 
	insert into dbo.[Country] (Code, Name) values 
		('CAD', 'Canada'), 
		('PHL', 'Philippines'); 
end 

if not exists (select 1 from dbo.[Users] ) 
begin 
	insert into dbo.[Users] (UserName, Email, [Password]) values 
		('marmagsael', 'marmagsael@gmail.com',hashbytes('sha2_512','01P@ssw0rd'));
	
end 

if not exists (select 1 from dbo.[MenuOCR] ) 
begin 
	


	insert into dbo.[MenuOCR]	([Odr], Id, IdParent,	[Indent], [Type], [Code], [Icon1],							[Icon2],	[DispText],				[IsWithChild],	[Controller],	[Action]) values 
								(10,	1,  0,			0,		  'Hdr',  'H001', '',								'',			'WORKSPACES',				1,				null,				null), 
								(20,	2,  0,			0,		  'Hdr',  'H002', '',								'',			'LIST',						1,				null,				null), 
								(30,	3,  0,			0,		  'Hdr',  'H003', '',								'',			'MANAGE',					1,				null,				null), 
								
								(11,	4,  1,			0,		  'SHdr', 'SH01', 'fa-solid fa-cart-shopping',		'',			'Cost',						1,				null,				null), 
								(12,	5,  1,			0,		  'SHdr', 'SH02', 'fa-solid fa-credit-card',		'',			'Sales',					1,				null,				null), 
								(13,	6,  1,			0,		  'SHdr', 'SH03', 'fa-solid fa-chart-line',			'',			'Expense Reports',			1,				null,				null), 
								(14,	7,  1,			0,		  'SHdr', 'SH04', 'fa-solid fa-building-columns',   '',			'Bank',						1,				null,				null),
								
								(20,	8,  2,			0,		  'Dtl',  'D001', 'fa-solid fa-truck',				'',			'Suppliers',				0,				'Main',				'_8Suppliers'), 
								(20,	9,  2,			0,		  'Dtl',  'D002', 'fa-solid fa-users',				'',			'Customers',				0,				'Main',				'_9Customers'), 
								(20,	10, 2,			0,		  'Dtl',  'D003', 'fa-solid fa-shapes',				'',			'Categories',				0,				'Main',				'_10Categories'), 
								(20,	11, 2,			0,		  'Dtl',  'D004', 'fa-solid fa-list-ul',			'',			'Projects',					0,				'Main',				'_11Projects'), 
								(20,	12, 2,			0,		  'Dtl',  'D005', 'fa-solid fa-building-user',      '',			'Bank Accounts',			0,				'Main',				'_12BankAccounts'), 
								(20,	13, 2,			0,		  'Dtl',  'D006', 'fa-solid fa-money-bill-wave',    '',			'Payment Methods',			0,				'Main',				'_13PaymentMethods'), 
								
								(11,	14, 4,			1,		  'Dtl',  'D007', 'fa-solid fa-inbox',				'',			'Inbox',					0,				'Costs',			'_14Inbox'),
								(11,	15, 4,			1,		  'Dtl',  'D008', 'fa-solid fa-gears',				'',			'In Processing',			0,				'Costs',			'_15InProcessing'), 
								(11,	16, 4,			1,		  'Dtl',  'D009', 'fa-solid fa-list-check',			'',			'To Review',				0,				'Costs',			'_16ToReview'), 
								(11,	17, 4,			1,		  'Dtl',  'D010', 'fa-regular fa-thumbs-up',		'',			'Ready',					0,				'Costs',			'_17Ready'), 
								(11,	18, 4,			1,		  'Dtl',  'D011', 'fa-solid fa-box-archive',		'',			'Archive',					0,				'Costs',			'_18Archive'),
								
								(12,	19, 5,			1,		  'Dtl',  'D012', 'fa-solid fa-inbox',				'',			'Inbox',					0,				'Sales',			'_19Inbox'),
								(12,	20, 5,			1,		  'Dtl',  'D013', 'fa-solid fa-gears',				'',			'In Processing',			0,				'Sales',			'_20InProcessing'), 
								(12,	21, 5,			1,		  'Dtl',  'D014', 'fa-solid fa-list-check',			'',			'To Review',				0,				'Sales',			'_21ToReview'), 
								(12,	22, 5,			1,		  'Dtl',  'D015', 'fa-regular fa-thumbs-up',		'',			'Ready',					0,				'Sales',			'_22Ready'), 
								(12,	23, 5,			1,		  'Dtl',  'D016', 'fa-solid fa-box-archive',		'',			'Archive',					0,				'Sales',			'_23Archive'),
								
								(13,	24, 6,			1,		  'Dtl',  'D017', 'fa-solid fa-inbox',				'',			'Inbox',					0,				'ExpenseReports',	'_24Inbox'), 
								(13,	25, 6,			1,		  'Dtl',  'D018', 'fa-solid fa-box-archive',		'',			'Archive',					0,				'ExpenseReports',	'_25Archive'),
								(13,	26, 7,			1,		  'Dtl',  'D019', 'fa-solid fa-person-chalkboard',  '',			'Overview',					0,				'Bank',				'_26Overview'), 
								(13,	27, 7,			1,		  'Dtl',  'D020', 'fa-solid fa-file-signature',     '',			'Collected Statements',		0,				'Bank',				'_27CollectedStatements'), 
								(13,	28, 7,			1,		  'Dtl',  'D021', 'fa-solid fa-file-circle-check',  '',			'Processed Statements',		0,				'Bank',				'_28ProcessedStatements'), 
								(13,	29, 7,			1,		  'Dtl',  'D022', 'fa-solid fa-handshake',			'',			'Transactions',				0,				'Bank',				'_29Transactions') 
								;
	
end 



