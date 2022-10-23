
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
	


	insert into dbo.[MenuOCR]	([Odr], Id, IdParent,	[Indent], [Type], [Code], [Icon1],[Icon2],[DispText],		[IsWithChild],	[Controller],	[Action]) values 
								(10,	1,  0,			0,		  'Hdr',  'H001', '',     '',     'WORKSPACES',		1,				null,				null), 
								(20,	2,  0,			0,		  'Hdr',  'H002', '',     '',     'LIST',			1,				null,				null), 
								(30,	3,  0,			0,		  'Hdr',  'H003', '',     '',     'MANAGE',			1,				null,				null), 
								
								(11,	4,  1,			0,		  'SHdr', 'SH01', '',     '',     'Cost',			1,				null,				null), 
								(12,	5,  1,			0,		  'SHdr', 'SH02', '',     '',     'Sales',			1,				null,				null), 
								(13,	6,  1,			0,		  'SHdr', 'SH03', '',     '',     'Expense Reports',1,				null,				null), 
								(14,	7,  1,			0,		  'SHdr', 'SH04', '',     '',     'Bank',			1,				null,				null),
								
								(20,	8,  2,			0,		  'Dtl',  'D001', '',     '',     'Suppliers',		0,				'MenuOcr',			'_8Suppliers'), 
								(20,	9,  2,			0,		  'Dtl',  'D002', '',     '',     'Customers',		0,				'MenuOcr',			'_9Customers'), 
								(20,	10, 2,			0,		  'Dtl',  'D003', '',     '',     'Categories',		0,				'MenuOcr',			'_10Categories'), 
								(20,	11, 2,			0,		  'Dtl',  'D004', '',     '',     'Projects',		0,				'MenuOcr',			'_11Projects'), 
								(20,	12, 2,			0,		  'Dtl',  'D005', '',     '',     'Bank Accounts',	0,				'MenuOcr',			'_12BankAccounts'), 
								(20,	13, 2,			0,		  'Dtl',  'D006', '',     '',     'Payment Methods',0,				'MenuOcr',			'_13PaymentMethods'), 
								
								(11,	14, 4,			1,		  'Dtl',  'D007', '',     '',     'Inbox',			0,				'MenuOcr',			'_14Inbox'),
								(11,	15, 4,			1,		  'Dtl',  'D008', '',     '',     'In Processing',	0,				'MenuOcr',			'_15InProcessing'), 
								(11,	16, 4,			1,		  'Dtl',  'D009', '',     '',     'To Review',		0,				'MenuOcr',			'_16ToReview'), 
								(11,	17, 4,			1,		  'Dtl',  'D010', '',     '',     'Ready',			0,				'MenuOcr',			'_17Ready'), 
								(11,	18, 4,			1,		  'Dtl',  'D011', '',     '',     'Archive',		0,				'MenuOcr',			'_18Archive'),
								
								(12,	19, 5,			1,		  'Dtl',  'D012', '',     '',     'Inbox',			0,				'MenuOcr',			'_19Inbox'),
								(12,	20, 5,			1,		  'Dtl',  'D013', '',     '',     'In Processing',	0,				'MenuOcr',			'_20InProcessing'), 
								(12,	21, 5,			1,		  'Dtl',  'D014', '',     '',     'To Review',		0,				'MenuOcr',			'_21ToReview'), 
								(12,	22, 5,			1,		  'Dtl',  'D015', '',     '',     'Ready',			0,				'MenuOcr',			'_22Ready'), 
								(12,	23, 5,			1,		  'Dtl',  'D016', '',     '',     'Archive',		0,				'MenuOcr',			'_23Archive'),
								
								(13,	24, 6,			1,		  'Dtl',  'D017', '',     '',     'Inbox',			0,				'MenuOcr',			'_24Inbox'), 
								(13,	25, 6,			1,		  'Dtl',  'D018', '',     '',     'Archive',		0,				'MenuOcr',			'_25Archive'),
								(13,	26, 7,			1,		  'Dtl',  'D019', '',     '',     'Overview',		0,				'MenuOcr',			'_26Overview'), 
								(13,	27, 7,			1,		  'Dtl',  'D020', '',     '',     'Collected Statements',	0,		'MenuOcr',			'_27CollectedStatements'), 
								(13,	28, 7,			1,		  'Dtl',  'D021', '',     '',     'Processed Statements',	0,		'MenuOcr',			'_28ProcessedStatements'), 
								(13,	29, 7,			1,		  'Dtl',  'D022', '',     '',     'Transactions',	0,				'MenuOcr',			'_29Transactions') 
								;
	
end 



