USE [dbvnm1212]
GO
/****** Object:  StoredProcedure [dbo].[SyncPromotion]    Script Date: 01/15/2014 11:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SyncPromotion](@date datetime=null) as
Begin
	BEGIN TRY
    
	/*	
select type from SaleOnline_PromotionProgram
	where type like 'zv%'
	group by type
select * from SaleOnline_PromotionProgram
--select * from SaleOnline_PromotionProgramDetail order by promotionprogramcode

insert into PROMOTIONS select * from rdodb_KT..PROMOTIONS
insert into PROMOTION_DETAIL select * from rdodb_KT..PROMOTION_DETAIL
insert into PROGRAM_PRODUCT select * from rdodb_KT..PROGRAM_PRODUCT
insert into PROMOTION_GIFTS select * from PROMOTION_GIFTS
insert into COUPON_STORES select * from rdodb_KT..COUPON_STORES
insert into PROGRAM_CATEGORY select * from rdodb_KT..PROGRAM_CATEGORY
insert into PROGRAM_MASTER_DATA select * from rdodb_KT..PROGRAM_MASTER_DATA
	*/
	Declare @maxDate datetime
	select @maxDate='9999/12/31'
	select PROMOTION_NO into #listPro from PROMOTIONS 
			where PROMOTION_NO in (select id from SaleOnline_PromotionProgram where synAction=2 or synAction=3	)
									
	select PROMOTION_DETAIL_NO into #listProDetail from PROMOTION_DETAIL where PROMOTION_NO in(select PROMOTION_NO from #listPro)
									
begin -- xóa dữ liệu các bảng KM
	delete from COUPON_STORES 
		where COUPON_NO in(select pd.PROMOTION_DETAIL_NO from PROMOTION_DETAIL pd
		inner join
		(select p.PROMOTION_NO,d.DEPT_CODE from PROMOTIONS p
			inner join SaleOnline_PromotionShopMap s
				on p.PROMOTION_NAME=s.promotionProgramCode
			inner join DEPT d on d.STORE_CODE=s.shopCode
			where synAction=3 or synAction=2 )sm
		on pd.PROMOTION_NO=sm.PROMOTION_NO		
		group by pd.PROMOTION_DETAIL_NO,sm.DEPT_CODE)	
		
	delete PROGRAM_MASTER_DATA where PROGRAM_NO in
	(select pd.PROMOTION_DETAIL_NO from PROMOTION_DETAIL pd inner join
		(select p.PROMOTION_NO,ad.customerTypeCode from SaleOnline_PromotionCustAttr a
		inner join SaleOnline_PromotionCustAttrDetail ad on a.id=ad.promotionCustAttrId
		inner join PROMOTIONS p on p.PROMOTION_NAME=a.promotionProgramCode where a.synAction=2 or a.synAction=3)cm
		on pd.PROMOTION_NO = cm.PROMOTION_NO
		group by pd.PROMOTION_DETAIL_NO,cm.customerTypeCode)								
																
	delete from PROMOTIONS where PROMOTION_NO in(select PROMOTION_NO from #listPro)
	delete from PROMOTION_DETAIL where PROMOTION_NO in(select PROMOTION_NO from #listPro)
	delete from PROGRAM_PRODUCT where PROGRAM_NO in (select PROMOTION_DETAIL_NO from #listProDetail)
	delete from PROMOTION_GIFTS where PROGRAM_NO in (select PROMOTION_DETAIL_NO from #listProDetail)
	--delete from COUPON_STORES where COUPON_NO in(select PROMOTION_DETAIL_NO from #listProDetail)
	--delete from PROGRAM_MASTER_DATA where PROGRAM_NO in(select PROMOTION_DETAIL_NO from #listProDetail)
	drop table #listPro,#listProDetail
end	
begin -- đồng bộ Promotions
	select * into #SaleOnline_PromotionProgram from SaleOnline_PromotionProgram where  (synAction=1 or synAction=2) and type like 'zv%' and status='RUNNING'
	select * into #SaleOnline_PromotionProgramDetail from SaleOnline_PromotionProgramDetail where synAction=1 or synAction=2
	
	insert into PROMOTIONS(PROMOTION_NO,PROMOTION_NAME,PROMOTION_DATE,FROM_DATE,TO_DATE,REMARK,INPUT_DATE,IS_ADD_MORE)
		select id,promotionProgramCode,LEFT(createDate,10),LEFT(fromDate,10),ISNULL(CONVERT(datetime,LEFT(toDate,10)),@maxDate),
				'',LEFT(createDate,10),0
			 from #SaleOnline_PromotionProgram
end			 

--====================================================
--------------------- Phần đồng bộ từng ct KM-------------			
begin -- đồng bộ các ct zv01,02	
	insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
		AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
		,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME)
	
	select  'PRMN.QUA.'+p.id+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY [productCode]desc) as varchar(12))[promotion_detail_no]
		,p.id[promotion_no],'QUA'[group_type],ISNULL(pd.saleQty,0)[Qua Min],9999[Qua Max],0[AMT Min],0[AMT Max]
		,0 [Qua Buy],null[Qua Dis],null[is_use_value],'PERCENT'[dis on],CONVERT(float,pd.discPer)[dis val],null[other],null[gift],0[qua gift]
		,null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resoan not used],'selected'[for products]
		, p.promotionProgramName from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where type ='zv01' and ISNULL(CONVERT(float,pd.discPer),0)>0 and pd.saleQty > 0
			--and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
		 order by p.promotionProgramCode 

insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
		AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
		,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME)
select  'PRMN.QUA.'+p.id+'.'+CAST(row_number() over 
	(PARTITION BY p.promotionProgramCode ORDER BY [productCode]desc) as varchar(12))[promotion_detail_no]
	,p.id[promotion_no],'QUA'[group_type],ISNULL(pd.saleQty,0)[Qua Min],9999[Qua Max],0[AMT Min],0[AMT Max]
	,0 [Qua Buy],null[Qua Dis],null[is_use_value],'AMOUNT'[dis on],CONVERT(float,pd.discAmt) [dis val],null[other],null[gift]
	,0[qua gift],null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resoan not used],'Selected'[for products]
	, p.promotionProgramName from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	 where   type ='zv02' and ISNULL(CONVERT(float,pd.discAmt),0) > 0 and pd.saleQty > 0
		--and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
	 order by p.promotionProgramCode

insert into PROGRAM_PRODUCT(PROGRAM_NO,PRODUCT_ID,FOR_TYPE)  
select  'PRMN.QUA.'+p.id+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY [productCode]desc) as varchar(12))[promotion_detail_no]
		,pd.productCode,null[fortype]
		 from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where type ='zv01' and ISNULL(CONVERT(float,pd.discPer),0)>0 and pd.saleQty > 0
			--and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
		 order by p.promotionProgramCode 

insert into PROGRAM_PRODUCT(PROGRAM_NO,PRODUCT_ID,FOR_TYPE) 
select  'PRMN.QUA.'+p.id+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY [productCode]desc) as varchar(12))[promotion_detail_no]
		,pd.productCode,null[fortype]
		 from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where type ='zv02' and ISNULL(CONVERT(float,pd.discAmt),0)>0 and pd.saleQty > 0
		 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
		 order by p.promotionProgramCode 
end		 
begin -- đồng bộ ctzv03
--z03 gif one
insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
		AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
		,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME)
select  'PRMzv031.QUA.'+p.id+'.'+CAST(row_number() over 
	(PARTITION BY p.promotionProgramCode ORDER BY [productCode]desc) as varchar(12))[promotion_detail_no]
	,p.id[promotion_no],'QUA'[group_type],ISNULL(MAX(pd.saleQty),0)[Qua Min],9999[Qua Max],0[AMT Min],0[AMT Max]
	,0 [Qua Buy],null[Qua Dis],null[is_use_value],'GIFTS'[dis on],0[dis val],null[other],'Selected'[gift],MAX(pd.freeQty) [qua gift]
	,null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resaon not used],'Selected'[for products]
	, MAX(p.promotionProgramName)	
 from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	 where   type ='zv03'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
group by pd.productCode,p.promotionProgramCode
		,pd.saleQty,p.id
	having MAX(pd.freeQty)=MIN(pd.freeQty)

select  'PRMzv031.QUA.'+p.id+'.'+CAST(row_number() over 
	(PARTITION BY p.promotionProgramCode ORDER BY [productCode]desc) as varchar(12))[promotion_detail_no]
	,p.id, p.promotionProgramCode,pd.saleQty,pd.productCode
	into #zv03GifOne
 from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	 where   type ='zv03'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
group by pd.productCode,p.promotionProgramCode
		,pd.saleQty,p.id
	having MAX(pd.freeQty)=MIN(pd.freeQty)
	

insert into PROGRAM_PRODUCT(PROGRAM_NO,PRODUCT_ID,FOR_TYPE) 
select  [promotion_detail_no]
	,p.productCode,null[fortype]
			from (select p.promotionProgramCode,productCode from #SaleOnline_PromotionProgram p
			left join #SaleOnline_PromotionProgramDetail pd
				on p.promotionProgramCode=pd.promotionProgramCode where   type ='zv03'  and pd.saleQty > 0
				group by pd.productCode
						,pd.saleQty,p.promotionProgramCode
					having MAX(pd.freeQty)=MIN(pd.freeQty))p
	inner join #zv03GifOne z on z.promotionProgramCode = p.promotionProgramCode	and p.productCode=z.productCode

insert into PROMOTION_GIFTS(PROGRAM_NO,PRODUCT_ID,FOR_TYPE)
select  [promotion_detail_no]
	,pd.freeProductCode,1[fortype]
	from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	inner join #zv03GifOne z on z.id = p.id and z.promotionProgramCode = p.promotionProgramCode and z.saleQty = pd.saleQty	
	 where   type ='zv03'  and pd.saleQty > 0 and z.ProductCode = pd.productCode --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
	group by pd.freeProductCode,[promotion_detail_no]
	
drop table #zv03GifOne
--z03 gif two
 insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
		AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
		,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME)
select  'PRMzv032.QUA.'+p.id+'.'+CAST(row_number() over 
	(PARTITION BY p.promotionProgramCode ORDER BY [productCode]desc) as varchar(12))[promotion_detail_no]
	,p.id[promotion_no],'QUA'[group_type],ISNULL(MAX(pd.saleQty),0)[Qua Min],9999[Qua Max],0[AMT Min],0[AMT Max]
	,0 [Qua Buy],null[Qua Dis],null[is_use_value],'GIFTS'[dis on],0[dis val],null[other],'Selected'[gift],MAX(pd.freeQty) [qua gift]
	,'Selected'[gift two]	,MIN(pd.freeQty)[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resaon not used],'Selected'[for products]
	, MAX(p.promotionProgramName)
 from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	 where   type ='zv03'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
group by pd.productCode,p.promotionProgramCode
		,pd.saleQty,p.id
	having MAX(pd.freeQty)<>MIN(pd.freeQty)

select  'PRMzv032.QUA.'+p.id+'.'+CAST(row_number() over 
	(PARTITION BY p.promotionProgramCode ORDER BY [saleQty]desc) as varchar(12))[promotion_detail_no]
	,p.id, p.promotionProgramCode,pd.saleQty,MAX(pd.freeQty)[gifOne],MIN(pd.freeQty)[gifTwo]
	into #zv03GifTwo
 from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	 where   type ='zv03'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
group by pd.productCode,p.promotionProgramCode
		,pd.saleQty,p.id
	having MAX(pd.freeQty)<>MIN(pd.freeQty)

insert into PROGRAM_PRODUCT(PROGRAM_NO,PRODUCT_ID,FOR_TYPE)	 		 
select  [promotion_detail_no]
	,pd.productCode,null[fortype]
	from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	inner join #zv03GifTwo z on z.id = p.id and z.promotionProgramCode = p.promotionProgramCode and z.saleQty = pd.saleQty	
	 where   type ='zv03'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
	 group by pd.productCode,[promotion_detail_no]

insert into PROMOTION_GIFTS(PROGRAM_NO,PRODUCT_ID,FOR_TYPE)
select  [promotion_detail_no]
	,pd.freeProductCode,1[fortype]
	from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	inner join #zv03GifTwo z on z.id = p.id and z.promotionProgramCode = p.promotionProgramCode and z.saleQty = pd.saleQty	
		and z.gifOne=pd.freeQty
	 where   type ='zv03'  and pd.saleQty > 0 --and z.ProductCode = pd.productCode --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
	group by pd.freeProductCode,[promotion_detail_no]

insert into PROMOTION_GIFTS(PROGRAM_NO,PRODUCT_ID,FOR_TYPE)	
select  [promotion_detail_no]
	,pd.freeProductCode,2[fortype]
	from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	inner join #zv03GifTwo z on z.id = p.id and z.promotionProgramCode = p.promotionProgramCode and z.saleQty = pd.saleQty	
		and z.gifTwo=pd.freeQty
	 where   type ='zv03'  and pd.saleQty > 0 --and z.ProductCode = pd.productCode --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
	group by pd.freeProductCode,[promotion_detail_no]

drop table 	#zv03GifTwo	
end 
begin -- đồng bộ ct zv07	 
insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
		AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
		,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME)
select  'PRMN.QUA.'+p.id+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY p.id desc) as varchar(12))[promotion_detail_no]
		,p.id[promotion_no],'QUA'[group_type],ISNULL(MAX(pd.saleQty),0)[Qua Min],9999[Qua Max],0[AMT Min],0[AMT Max]
		,0 [Qua Buy],null[Qua Dis],null[is_use_value],'PERCENT'[dis on],CONVERT(float,MAX(pd.discPer))[dis val],null[other],null[gift],0[qua gift]
		,null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resoan not used],'selected'[for products]
		, MAX(p.promotionProgramName) from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where type ='zv07' and ISNULL(CONVERT(float,pd.discPer),0)>0 and pd.saleQty > 0
			--and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
		group by p.promotionProgramCode,p.id
		 order by p.promotionProgramCode 

insert into PROGRAM_PRODUCT(PROGRAM_NO,PRODUCT_ID,FOR_TYPE)	 
select  'PRMN.QUA.'+p.id+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode,pd.productCode ORDER BY p.id desc) as varchar(12))[promotion_detail_no]
		,pd.productCode,null[fortype]
		from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where type ='zv07' and ISNULL(CONVERT(float,pd.discPer),0)>0 and pd.saleQty > 0
			--and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
		group by p.promotionProgramCode,pd.productCode,p.id
		 order by p.promotionProgramCode
end
begin -- đồng bộ ct zv08
insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
		AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
		,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME)
select  'PRMN.QUA.'+p.id+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY p.id desc) as varchar(12))[promotion_detail_no]
		,p.id[promotion_no],'QUA'[group_type],ISNULL(MAX(pd.saleQty),0)[Qua Min],9999[Qua Max],0[AMT Min],0[AMT Max]
		,0 [Qua Buy],null[Qua Dis],null[is_use_value],'AMOUNT'[dis on],CONVERT(float,MAX(pd.discAmt))[dis val],null[other],null[gift],0[qua gift]
		,null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resoan not used],'selected'[for products]
		, MAX(p.promotionProgramName) from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where type ='zv08' and ISNULL(CONVERT(float,pd.discAmt),0)>0 and pd.saleQty > 0
			--and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
		group by p.promotionProgramCode,p.id
		 order by p.promotionProgramCode

insert into PROGRAM_PRODUCT(PROGRAM_NO,PRODUCT_ID,FOR_TYPE)	 		 
select  'PRMN.QUA.'+p.id+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode,pd.productCode ORDER BY p.id desc) as varchar(12))[promotion_detail_no]
		,pd.productCode,null[fortype]
		from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where type ='zv08' and ISNULL(CONVERT(float,pd.discAmt),0)>0 and pd.saleQty > 0
			--and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
		group by p.promotionProgramCode,pd.productCode,p.id
		 order by p.promotionProgramCode 
end		 
begin -- đồng bộ ct zv09
--z09 gif one		 

insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
		AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
		,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME)
select  'PRMzv091.QUA.'+p.id+'.'+CAST(row_number() over 
	(PARTITION BY p.promotionProgramCode ORDER BY [saleQty]desc) as varchar(12))[promotion_detail_no]
	,p.id[promotion_no],'QUA'[group_type],ISNULL(MAX(pd.saleQty),0)[Qua Min],9999[Qua Max],0[AMT Min],0[AMT Max]
	,0 [Qua Buy],null[Qua Dis],null[is_use_value],'PERCENT'[dis on],0[dis val],null[other],'Selected'[gift],MAX(pd.freeQty) [qua gift]
	,null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resaon not used],'Selected'[for products]
	, MAX(p.promotionProgramName)	
 from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	 where   type ='zv09'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
group by p.promotionProgramCode
		,pd.saleQty,p.id
	having MAX(pd.freeQty)=MIN(pd.freeQty)

select  'PRMzv091.QUA.'+p.id+'.'+CAST(row_number() over 
	(PARTITION BY p.promotionProgramCode ORDER BY [saleQty]desc) as varchar(12))[promotion_detail_no]
	,p.id, p.promotionProgramCode,pd.saleQty
	into #zv09GifOne
 from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	 where   type ='zv09'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
group by p.promotionProgramCode
		,pd.saleQty,p.id
	having MAX(pd.freeQty)=MIN(pd.freeQty)

insert into PROGRAM_PRODUCT(PROGRAM_NO,PRODUCT_ID,FOR_TYPE)
select  [promotion_detail_no]
	,pd.productCode,null[fortype]
	from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	inner join #zv09GifOne z on z.id = p.id and z.promotionProgramCode = p.promotionProgramCode and z.saleQty = pd.saleQty	
	 where   type ='zv09'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
	 group by pd.productCode,[promotion_detail_no]

insert into PROMOTION_GIFTS(PROGRAM_NO,PRODUCT_ID,FOR_TYPE)
select  [promotion_detail_no]
	,pd.freeProductCode,1[fortype]
	from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	inner join #zv09GifOne z on z.id = p.id and z.promotionProgramCode = p.promotionProgramCode and z.saleQty = pd.saleQty	
	 where   type ='zv09'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
	group by pd.freeProductCode,[promotion_detail_no]
drop table 	#zv09GifOne
--end zv09 gif one

--zv09 gif Two

insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
		AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
		,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME)
select  'PRMzv092.QUA.'+p.id+'.'+CAST(row_number() over 
	(PARTITION BY p.promotionProgramCode ORDER BY [saleQty]desc) as varchar(12))[promotion_detail_no]
	,p.id[promotion_no],'QUA'[group_type],ISNULL(MAX(pd.saleQty),0)[Qua Min],9999[Qua Max],0[AMT Min],0[AMT Max]
	,0 [Qua Buy],null[Qua Dis],null[is_use_value],'PERCENT'[dis on],0[dis val],null[other],'Selected'[gift],MAX(pd.freeQty) [qua gift]
	,'Selected'[gift two]	,MIN(pd.freeQty)[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resaon not used],'Selected'[for products]
	, MAX(p.promotionProgramName)	
 from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	 where   type ='zv09'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
group by p.promotionProgramCode
		,pd.saleQty,p.id
	having MAX(pd.freeQty)<>MIN(pd.freeQty)

select  'PRMzv092.QUA.'+p.id+'.'+CAST(row_number() over 
	(PARTITION BY p.promotionProgramCode ORDER BY [saleQty]desc) as varchar(12))[promotion_detail_no]
	,p.id, p.promotionProgramCode,pd.saleQty,MAX(pd.freeQty)[gifOne],MIN(pd.freeQty)[gifTwo]
	into #zv09GifTwo
 from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	 where   type ='zv09'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
group by p.promotionProgramCode
		,pd.saleQty,p.id
	having MAX(pd.freeQty)<>MIN(pd.freeQty)

insert into PROGRAM_PRODUCT(PROGRAM_NO,PRODUCT_ID,FOR_TYPE)	 		 
select  [promotion_detail_no]
	,pd.productCode,null[fortype]
	from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	inner join #zv09GifTwo z on z.id = p.id and z.promotionProgramCode = p.promotionProgramCode and z.saleQty = pd.saleQty	
	 where   type ='zv09'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
	 group by pd.productCode,[promotion_detail_no]

insert into PROMOTION_GIFTS(PROGRAM_NO,PRODUCT_ID,FOR_TYPE)
select  [promotion_detail_no]
	,pd.freeProductCode,1[fortype]
	from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	inner join #zv09GifTwo z on z.id = p.id and z.promotionProgramCode = p.promotionProgramCode and z.saleQty = pd.saleQty	
		and z.gifOne=pd.freeQty
	 where   type ='zv09'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
	group by pd.freeProductCode,[promotion_detail_no]

insert into PROMOTION_GIFTS(PROGRAM_NO,PRODUCT_ID,FOR_TYPE)	
select  [promotion_detail_no]
	,pd.freeProductCode,2[fortype]
	from #SaleOnline_PromotionProgram p
	left join #SaleOnline_PromotionProgramDetail pd
		on p.promotionProgramCode=pd.promotionProgramCode
	inner join #zv09GifTwo z on z.id = p.id and z.promotionProgramCode = p.promotionProgramCode and z.saleQty = pd.saleQty	
		and z.gifTwo=pd.freeQty
	 where   type ='zv09'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
	group by pd.freeProductCode,[promotion_detail_no]
drop table 	#zv09GifTwo
end
begin --đồng bộ ct zv13
 Declare @idPro int
 declare @productInBundle int,@producInProgram int,@pro int

select p.id,pd.saleQty,pd.productCode,pd.discPer[discAmt],p.promotionProgramName
into #zv13
 from  #SaleOnline_PromotionProgram p	
	left join #SaleOnline_PromotionProgramDetail pd on p.promotionProgramCode=pd.promotionProgramCode
	where   type ='zv13'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date

select productCode,id 
into #productBundleZv13 
from  #zv13
		group by productCode,id
select discAmt,ROW_NUMBER()over(partition by id order by discAmt)[pro],id 
	into #freeAMTBundleZv13 
	from  #zv13
		group by discAmt,id
Declare cur_cursor13 Cursor for select id From #zv13 group by id
Open cur_cursor13
FETCH NEXT FROM cur_cursor13 
  INTO @idPro
WHILE @@FETCH_STATUS = 0
BEGIN    	
	select @productInBundle=COUNT(*) from #productBundleZv13 where id=@idPro

	select @producInProgram=COUNT(*) from(
		select productCode,saleQty from  #zv13
		where id=@idPro
		group by productCode,saleQty)v		
	select @pro=1
	while @pro <= @producInProgram/@productInBundle
	Begin
		insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
			AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
			,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME,IS_BUNDLE)
		
		select  'PRMzv13.QUA.'+CAST(@idPro as varchar(10))+'.'+cast(@pro as varchar(10))[promotion_detail_no]
		,id[promotion_no],'QUA'[group_type],0[Qua Min],9999[Qua Max],0[AMT Min],0[AMT Max]
		,0 [Qua Buy],null[Qua Dis],null[is_use_value],'PERCENT'[dis on],CONVERT(float,min(discAmt)) [dis val],null[other],null[gift]
		,0[qua gift],null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resaon not used],'Selected'[for products]
		, MAX(promotionProgramName)[promotionProgramName],'1'[isBundle]	
		from #zv13 where id=@idPro
		group by id
		
		insert into PROGRAM_PRODUCT(PROGRAM_NO,PRODUCT_ID,QUANTITY)	 
		select 'PRMzv13.QUA.'+CAST(@idPro as varchar(10))+'.'+cast(@pro as varchar(10))[promotion_detail_no]
			,productCode,saleQty from #zv13 
			where id=@idPro					
			and discAmt in (select discAmt from #freeAMTBundleZv13 where pro=@pro and id=@idPro)
		
		select @pro=@pro+1		
	end
  
FETCH NEXT FROM cur_cursor13 
  INTO @idPro
END
Close cur_cursor13
DEALLOCATE cur_cursor13
drop table #zv13,#productBundleZv13,#freeAMTBundleZv13

end 
begin -- đồng bộ ctzv14
select p.id,pd.saleQty,pd.productCode,pd.discAmt,p.promotionProgramName
into #zv14
 from  #SaleOnline_PromotionProgram p	
	left join #SaleOnline_PromotionProgramDetail pd on p.promotionProgramCode=pd.promotionProgramCode
	where   type ='zv14'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date

select productCode,id 
into #productBundleZv14 
from  #zv14
		group by productCode,id
select discAmt,ROW_NUMBER()over(partition by id order by discAmt)[pro],id 
	into #freeAMTBundleZv14 
	from  #zv14
		group by discAmt,id
Declare cur_cursor14 Cursor for select id From #zv14 group by id
--Declare @idPro int
Open cur_cursor14
FETCH NEXT FROM cur_cursor14 
  INTO @idPro
WHILE @@FETCH_STATUS = 0
BEGIN    
	--declare @productInBundle int,@producInProgram int,@pro int
	select @productInBundle=COUNT(*) from #productBundleZv14 where id=@idPro

	select @producInProgram=COUNT(*) from(
		select productCode,saleQty from  #zv14
		where id=@idPro
		group by productCode,saleQty)v		
	select @pro=1
	while @pro <= @producInProgram/@productInBundle
	Begin
		insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
			AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
			,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME,IS_BUNDLE)
		
		select  'PRMzv14.QUA.'+CAST(@idPro as varchar(10))+'.'+cast(@pro as varchar(10))[promotion_detail_no]
		,id[promotion_no],'QUA'[group_type],0[Qua Min],9999[Qua Max],0[AMT Min],0[AMT Max]
		,0 [Qua Buy],null[Qua Dis],null[is_use_value],'AMOUNT'[dis on],CONVERT(float,min(discAmt)) [dis val],null[other],null[gift]
		,0[qua gift],null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resaon not used],'Selected'[for products]
		, MAX(promotionProgramName)[promotionProgramName],'1'[isBundle]	
		from #zv14 where id=@idPro
		group by id
		
		insert into PROGRAM_PRODUCT(PROGRAM_NO,PRODUCT_ID,QUANTITY)	 
		select 'PRMzv14.QUA.'+CAST(@idPro as varchar(10))+'.'+cast(@pro as varchar(10))[promotion_detail_no]
			,productCode,saleQty from #zv14 
			where id=@idPro					
			and discAmt in (select discAmt from #freeAMTBundleZv14 where pro=@pro and id=@idPro)
		
		select @pro=@pro+1		
	end
  
FETCH NEXT FROM cur_cursor14 
  INTO @idPro
END
Close cur_cursor14
DEALLOCATE cur_cursor14
drop table #zv14,#productBundleZv14,#freeAMTBundleZv14
end
begin -- đồng bộ ct zv15

select p.id,pd.saleQty,pd.productCode,pd.freeQty,pd.freeProductCode,p.promotionProgramName
into #zv15
 from  #SaleOnline_PromotionProgram p	
	left join #SaleOnline_PromotionProgramDetail pd on p.promotionProgramCode=pd.promotionProgramCode
	where   type ='zv15'  and pd.saleQty > 0 --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date

select productCode,id 
into #productBundle 
from  #zv15
		group by productCode,id
		
select freeProductCode,freeQty,ROW_NUMBER()over(partition by id order by freeQty)[pro],id 
	into #freeProductBundle 
	from  #zv15
		group by freeProductCode,freeQty,id

Declare cur_cursor15 Cursor for select id From #zv15 group by id
--Declare @idPro int
Open cur_cursor15
FETCH NEXT FROM cur_cursor15 
  INTO @idPro
WHILE @@FETCH_STATUS = 0
BEGIN    
	--declare @productInBundle int,@producInProgram int,@pro int
	select @productInBundle=COUNT(*) from #productBundle where id=@idPro

	select @producInProgram=COUNT(*) from(
		select productCode,saleQty from  #zv15
		where id=@idPro
		group by productCode,saleQty)v		
	select @pro=1
	while @pro <= @producInProgram/@productInBundle
	Begin
		insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
			AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
			,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME,IS_BUNDLE)
		
		select  'PRMzv15.QUA.'+CAST(@idPro as varchar(10))+'.'+cast(@pro as varchar(10))[promotion_detail_no]
		,id[promotion_no],'QUA'[group_type],0[Qua Min],9999[Qua Max],0[AMT Min],0[AMT Max]
		,0 [Qua Buy],null[Qua Dis],null[is_use_value],'PERCENT'[dis on],0[dis val],null[other],null[gift],0 [qua gift]
		,null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resaon not used],'Selected'[for products]
		, MAX(promotionProgramName)[promotionProgramName],'1'[isBundle]	
		from #zv15 where id=@idPro
		group by id
		
		insert into PROGRAM_PRODUCT(PROGRAM_NO,PRODUCT_ID,QUANTITY)	 
		select 'PRMzv15.QUA.'+CAST(@idPro as varchar(10))+'.'+cast(@pro as varchar(10))[promotion_detail_no]
			,productCode,saleQty from #zv15 
			where id=@idPro
			and freeProductCode in (select freeProductCode from #freeProductBundle where pro=@pro and id=@idPro)		
			and freeQty in (select freeQty from #freeProductBundle where pro=@pro and id=@idPro)	
		
		insert into PROMOTION_GIFTS(PROGRAM_NO,PRODUCT_ID,QUANTITY,FOR_TYPE)
		select 'PRMzv15.QUA.'+CAST(@idPro as varchar(10))+'.'+cast(@pro as varchar(10))[promotion_detail_no]
			,freeProductCode,freeQty,1 from #zv15 
			where id=@idPro
			and ((freeProductCode in (select freeProductCode from #freeProductBundle where pro=@pro and id=@idPro)
			and freeQty in (select freeQty from #freeProductBundle where pro=@pro  and id=@idPro))	
			or @producInProgram/@productInBundle < (select MAX(pro) from #freeProductBundle where id=@idPro))
		group by freeProductCode,freeQty
		
		select @pro=@pro+1		
	end
  
FETCH NEXT FROM cur_cursor15 
  INTO @idPro
END
Close cur_cursor15
DEALLOCATE cur_cursor15
drop table #zv15,#productBundle,#freeProductBundle
end 
begin -- đồng bộ ct zv19,20,21
insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
		AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
		,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME)	
	select  'PRMzv19.QUA.'+p.id+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY [productCode]desc) as varchar(12))[promotion_detail_no]
		,p.id[promotion_no],'QUA'[group_type],ISNULL(pd.saleQty,0)[Qua Min],9999[Qua Max],pd.saleAmt [AMT Min],0[AMT Max]
		,0 [Qua Buy],null[Qua Dis],null[is_use_value],'PERCENT'[dis on],CONVERT(float,pd.discPer)[dis val],null[other],null[gift],0[qua gift]
		,null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resoan not used],'selected'[for products]
		, p.promotionProgramName from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where type ='zv19' and ISNULL(CONVERT(float,pd.discPer),0)>0 and pd.saleAmt > 0
			--and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
		 order by p.promotionProgramCode 
		 
		 insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
		AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
		,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME)	
	select  'PRMzv20.QUA.'+p.id+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY [productCode]desc) as varchar(12))[promotion_detail_no]
		,p.id[promotion_no],'QUA'[group_type],ISNULL(pd.saleQty,0)[Qua Min],9999[Qua Max],pd.saleAmt [AMT Min],0[AMT Max]
		,0 [Qua Buy],null[Qua Dis],null[is_use_value],'AMOUNT'[dis on],CONVERT(float,pd.discAmt)[dis val],null[other],null[gift],0[qua gift]
		,null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resoan not used],'selected'[for products]
		, p.promotionProgramName from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where type ='zv20' and ISNULL(CONVERT(float,pd.discAmt),0)>0 and pd.saleAmt > 0
			--and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
		 order by p.promotionProgramCode 
		 
		 
		 insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
		AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
		,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME)
		 select  'PRMzv21.QUA.'+p.id+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY [productCode]desc) as varchar(12))[promotion_detail_no]
		,p.id[promotion_no],'QUA'[group_type],ISNULL(pd.saleQty,0)[Qua Min],9999[Qua Max],pd.saleAmt [AMT Min],0[AMT Max]
		,0 [Qua Buy],null[Qua Dis],null[is_use_value],'GIFTS'[dis on],CONVERT(float,pd.discAmt)[dis val],null[other],null[gift],0[qua gift]
		,null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resoan not used],'selected'[for products]
		, p.promotionProgramName from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where type ='zv21' and pd.saleAmt > 0
			--and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
		 order by p.promotionProgramCode 
		 
		 
		 	
			select  'PRMzv21.QUA.'+p.id+'.'+CAST(row_number() over 
			(PARTITION BY p.promotionProgramCode ORDER BY [productCode]desc) as varchar(12))[promotion_detail_no]
			,p.id, p.promotionProgramCode,pd.freeQty,pd.saleQty
			into #zv21GifOne
		 from #SaleOnline_PromotionProgram p
			left join #SaleOnline_PromotionProgramDetail pd
				on p.promotionProgramCode=pd.promotionProgramCode
			 where   type ='zv21'   and (pd.saleAmt > 0 or pd.freeQty > 0) --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
		group by pd.productCode,p.promotionProgramCode
				,pd.saleQty,p.id,pd.freeQty
				
			
		 
		 insert into PROMOTION_GIFTS(PROGRAM_NO,PRODUCT_ID,FOR_TYPE,QUANTITY)
		select  [promotion_detail_no]
			,pd.freeProductCode,1[fortype],z.freeQty
			from #SaleOnline_PromotionProgram p
			left join #SaleOnline_PromotionProgramDetail pd
				on p.promotionProgramCode=pd.promotionProgramCode	
				inner join #zv21GifOne z on z.id = p.id and z.promotionProgramCode = p.promotionProgramCode and isNull(z.freeQty,0) = IsNull(pd.freeQty,0)	
				and isNull(z.saleQty,0)= isNull(pd.saleQty,0)		
			 where   type ='zv21'  and (pd.saleAmt > 0 or pd.freeQty > 0) --and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
			group by pd.freeProductCode,[promotion_detail_no],z.freeQty
		
end 
begin --đồng bộ ct z4,5,6 
--select * from SaleOnline_PromotionProgramDetail where promotionProgramCode like 'KTZV1%'
insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
		AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
		,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME)	
	select  'PRM'+type+'.QUA.'+p.id+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY [productCode]desc) as varchar(12))[promotion_detail_no]
		,p.id[promotion_no],'QUA'[group_type],ISNULL(pd.saleQty,0)[Qua Min],9999[Qua Max],pd.saleAmt [AMT Min],0[AMT Max]
		,0 [Qua Buy],null[Qua Dis],null[is_use_value],
		Case when type = 'zv06' then 'GIFTS' when TYPE = 'zv05' then 'AMOUNT' else 'PERCENT' end [dis on],
		CONVERT(float,case when TYPE = 'zv05' then discAmt else discPer end) [dis val],null[other],null[gift],0[qua gift]
		,null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resoan not used],'selected'[for products]
		, p.promotionProgramName from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where (type ='zv04' or type ='zv05' or type ='zv06') and pd.saleAmt > 0
			--and  CONVERT(datetime,LEFT(p.createDate,10))>=@date
		 order by p.promotionProgramCode 
		 
		 insert into PROGRAM_PRODUCT(PROGRAM_NO,PRODUCT_ID,QUANTITY)	 
		select 'PRM'+type+'.QUA.'+p.id+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY [productCode]desc) as varchar(12)) [promotion_detail_no]
			,productCode,saleQty  
			from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
			where (type ='zv04' or type ='zv05' or type ='zv06') and pd.saleAmt > 0
			
		 
	insert into PROMOTION_GIFTS(PROGRAM_NO,PRODUCT_ID,FOR_TYPE,QUANTITY)
		select 'PRM'+type+'.QUA.'+p.id+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY [productCode]desc) as varchar(12)) [promotion_detail_no]
			,pd.freeProductCode,1[fortype],pd.freeQty
			from #SaleOnline_PromotionProgram p
			left join #SaleOnline_PromotionProgramDetail pd
				on p.promotionProgramCode=pd.promotionProgramCode									
			 where   type ='zv06'  and pd.saleAmt > 0 and pd.freeQty > 0
			group by pd.freeProductCode,pd.freeQty,p.id,p.promotionProgramCode,[productCode],type
end 
begin -- đồng bộ ct z10,11,12 
--select * from SaleOnline_PromotionProgramDetail where promotionProgramCode like 'KTZV1%'
insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
		AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
		,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME)	
	select  'PRM'+type+'.QUA.'+Max(p.id)+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY ISNULL(discPer,0),ISNULL(discAmt,0),ISNULL(freeQty,0) desc) as varchar(12))[promotion_detail_no]
		,max(p.id) [promotion_no],'QUA'[group_type],ISNULL(Max(pd.saleQty),0)[Qua Min],9999[Qua Max],pd.saleAmt [AMT Min],0[AMT Max]
		,0 [Qua Buy],null[Qua Dis],null[is_use_value],
		Case when type = 'zv12' then 'GIFTS' when TYPE = 'zv11' then 'AMOUNT' else 'PERCENT' end [dis on],
		CONVERT(float,case when TYPE = 'zv11' then ISNULL(discAmt,0) else ISNULL(discPer,0) end) [dis val],null[other],null[gift],0[qua gift]
		,null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resoan not used],'selected'[for products]
		, p.promotionProgramName from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where (type ='zv10' or type ='zv11' or type ='zv12') and pd.saleAmt > 0
			group by ISNULL(discPer,0),ISNULL(discAmt,0),ISNULL(freeQty,0),Type,p.promotionProgramCode,pd.saleAmt,p.promotionProgramName
		 order by p.promotionProgramCode 
		 
		 select  'PRM'+type+'.QUA.'+Max(p.id)+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY ISNULL(discPer,0),ISNULL(discAmt,0),ISNULL(freeQty,0) desc) as varchar(12))[promotion_detail_no]
		,max(p.id) [promotion_no],ISNULL(discPer,0) discPer,ISNULL(discAmt,0)discAmt,pd.saleAmt [AMT Min],ISNULL(freeQty,0) freeQty		
		, p.promotionProgramCode into #gif101112 from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where (type ='zv10' or type ='zv11' or type ='zv12') and pd.saleAmt > 0
			group by ISNULL(discPer,0),ISNULL(discAmt,0),ISNULL(freeQty,0),Type,p.promotionProgramCode,pd.saleAmt,p.promotionProgramName
		 order by p.promotionProgramCode 
		 
		 insert into PROGRAM_PRODUCT(PROGRAM_NO,PRODUCT_ID,QUANTITY)	 
		select g.[promotion_detail_no] [promotion_detail_no]
			,productCode,saleQty  
			from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd		
			on p.promotionProgramCode=pd.promotionProgramCode
		inner join #gif101112 g ON pd.promotionProgramCode = g.promotionProgramCode
		and ISNULL(pd.discPer,0) = ISNULL(g.discPer,0) and ISNULL(pd.discAmt,0) = ISNULL(g.discAmt,0) and
		pd.saleAmt = g.[AMT Min] and ISNULL(pd.freeQty,0) = ISNULL(g.freeQty,0)
			where (type ='zv10' or type ='zv11' or type ='zv12') and pd.saleAmt > 0
			group by ISNULL(g.discPer,0),ISNULL(g.discAmt,0),ISNULL(g.freeQty,0),productCode,saleQty,p.promotionProgramCode,type
			,g.[promotion_detail_no]
			
		 
	insert into PROMOTION_GIFTS(PROGRAM_NO,PRODUCT_ID,FOR_TYPE,QUANTITY)
		select distinct g.[promotion_detail_no] [promotion_detail_no]
			,pd.freeProductCode,1[fortype],ISNULL(pd.freeQty,0)
			from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd		
			on p.promotionProgramCode=pd.promotionProgramCode
		inner join #gif101112 g ON pd.promotionProgramCode = g.promotionProgramCode
		and ISNULL(pd.discPer,0) = ISNULL(g.discPer,0) and ISNULL(pd.discAmt,0) = ISNULL(g.discAmt,0) and
		pd.saleAmt = g.[AMT Min] and ISNULL(pd.freeQty,0) = ISNULL(g.freeQty,0)
			where (type ='zv10' or type ='zv11' or type ='zv12') and pd.saleAmt > 0 and ISNULL(pd.freeQty,0) <> 0
			group by ISNULL(g.discPer,0),ISNULL(g.discAmt,0),ISNULL(pd.freeQty,0),productCode,p.promotionProgramCode,type,ISNULL(g.freeQty,0)
			,g.[promotion_detail_no],pd.freeProductCode 
			
	end 	
begin	-- đồng bộ ct z16,17,18 
--select * from SaleOnline_PromotionProgramDetail where promotionProgramCode like 'KTZV1%'
insert into PROMOTION_DETAIL(PROMOTION_DETAIL_NO,PROMOTION_NO,GROUP_TYPE,QUANTITY_MIN,QUANTITY_MAX,AMOUNT_MIN,
		AMOUNT_MAX,QUANTITY_BUY,QUANTITY_DISCOUNT,IS_USED_VALUE,DISCOUNT_ON,DISCOUNT_VALUE,OTHER_VALUE,GIFT,QUANTITY_GIFT,GIFT_TWO,QUANTITY_GIFT_TWO
		,NUMBER_MARK,STATUS,REASON_NOT_USED,FOR_PRODUCTS,PROMOTION_DETAIL_NAME,IS_BUNDLE)	
	select  'PRM'+type+'.QUA.'+Max(p.id)+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY ISNULL(discPer,0),ISNULL(discAmt,0),ISNULL(freeQty,0) desc) as varchar(12))[promotion_detail_no]
		,max(p.id) [promotion_no],'QUA'[group_type],ISNULL(Max(pd.saleQty),0)[Qua Min],9999[Qua Max],Sum(cast(pd.saleAmt as float)) [AMT Min],0[AMT Max]
		,0 [Qua Buy],null[Qua Dis],null[is_use_value],
		Case when type = 'zv18' then 'GIFTS' when TYPE = 'zv17' then 'AMOUNT' else 'PERCENT' end [dis on],
		CONVERT(float,case when TYPE = 'zv17' then ISNULL(discAmt,0) else ISNULL(discPer,0) end) [dis val],null[other],null[gift],0[qua gift]
		,null[gift two]	,0[Qua gift two],0[num mark],'ACTIVED'[Status],NULL[resoan not used],'selected'[for products]
		, p.promotionProgramName,1 from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where (type ='zv16' or type ='zv17' or type ='zv18') and pd.saleAmt > 0
			group by ISNULL(discPer,0),ISNULL(discAmt,0),ISNULL(freeQty,0),Type,p.promotionProgramCode,p.promotionProgramName
		 order by p.promotionProgramCode 
		 
		 select  'PRM'+type+'.QUA.'+Max(p.id)+'.'+CAST(row_number() over 
		(PARTITION BY p.promotionProgramCode ORDER BY ISNULL(discPer,0),ISNULL(discAmt,0),ISNULL(freeQty,0) desc) as varchar(12))[promotion_detail_no]
		,max(p.id) [promotion_no],ISNULL(discPer,0) discPer,ISNULL(discAmt,0)discAmt,Sum(cast(pd.saleAmt as float)) [AMT Min],ISNULL(freeQty,0) freeQty		
		, p.promotionProgramCode into #gif161718 from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd
			on p.promotionProgramCode=pd.promotionProgramCode
		 where (type ='zv16' or type ='zv17' or type ='zv18') and pd.saleAmt > 0
			group by ISNULL(discPer,0),ISNULL(discAmt,0),ISNULL(freeQty,0),Type,p.promotionProgramCode,p.promotionProgramName		
		 order by p.promotionProgramCode 
		 
		 
		 insert into PROGRAM_PRODUCT(PROGRAM_NO,PRODUCT_ID,QUANTITY)	 
		select g.[promotion_detail_no] [promotion_detail_no]
			,productCode,pd.saleAmt  
			from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd		
			on p.promotionProgramCode=pd.promotionProgramCode
		inner join #gif161718 g ON pd.promotionProgramCode = g.promotionProgramCode
		and ISNULL(pd.discPer,0) = ISNULL(g.discPer,0) and ISNULL(pd.discAmt,0) = ISNULL(g.discAmt,0) and
		 ISNULL(pd.freeQty,0) = ISNULL(g.freeQty,0)
			where (type ='zv16' or type ='zv17' or type ='zv18') and pd.saleAmt > 0
			group by ISNULL(g.discPer,0),ISNULL(g.discAmt,0),ISNULL(g.freeQty,0),productCode,p.promotionProgramCode,type
			,g.[promotion_detail_no],pd.saleAmt  
			
		 
	insert into PROMOTION_GIFTS(PROGRAM_NO,PRODUCT_ID,FOR_TYPE,QUANTITY)
		select distinct g.[promotion_detail_no] [promotion_detail_no]
			,pd.freeProductCode,1[fortype],ISNULL(pd.freeQty,0)
			from #SaleOnline_PromotionProgram p
		left join #SaleOnline_PromotionProgramDetail pd		
			on p.promotionProgramCode=pd.promotionProgramCode
		inner join #gif161718 g ON pd.promotionProgramCode = g.promotionProgramCode
		and ISNULL(pd.discPer,0) = ISNULL(g.discPer,0) and ISNULL(pd.discAmt,0) = ISNULL(g.discAmt,0) 
		and ISNULL(pd.freeQty,0) = ISNULL(g.freeQty,0)
			where (type ='zv16' or type ='zv17' or type ='zv18') and pd.saleAmt > 0 and ISNULL(pd.freeQty,0) <> 0
			group by ISNULL(g.discPer,0),ISNULL(g.discAmt,0),ISNULL(pd.freeQty,0),productCode,p.promotionProgramCode,type,ISNULL(g.freeQty,0)
			,g.[promotion_detail_no],pd.freeProductCode 
			
	end 
	
begin -- đồng bộ coupon và custumergroup
insert into COUPON_STORES(COUPON_NO,DEPT_CODE)
select pd.PROMOTION_DETAIL_NO,sm.DEPT_CODE from PROMOTION_DETAIL pd
	inner join
	(select p.PROMOTION_NO,d.DEPT_CODE from PROMOTIONS p
		inner join SaleOnline_PromotionShopMap s
			on p.PROMOTION_NAME=s.promotionProgramCode
		inner join DEPT d on d.STORE_CODE=s.shopCode
		where synAction=1 or synAction=2)sm
	on pd.PROMOTION_NO=sm.PROMOTION_NO	
	where pd.PROMOTION_DETAIL_NO+cast(sm.DEPT_CODE as varchar(20)) not in (Select COUPON_NO + cast(DEPT_CODE as varchar(20)) from COUPON_STORES)
	group by pd.PROMOTION_DETAIL_NO,sm.DEPT_CODE
	
	 
---	
--PROGRAM_MASTER_DATA


insert into PROGRAM_MASTER_DATA(PROGRAM_NO,MASTER_CODE)
select pd.PROMOTION_DETAIL_NO,cm.customerTypeCode from PROMOTION_DETAIL pd inner join
	(select p.PROMOTION_NO,ad.customerTypeCode from SaleOnline_PromotionCustAttr a
	inner join SaleOnline_PromotionCustAttrDetail ad on a.id=ad.promotionCustAttrId
	inner join PROMOTIONS p on p.PROMOTION_NAME=a.promotionProgramCode where a.synAction=1 or a.synAction=2)cm
	on pd.PROMOTION_NO = cm.PROMOTION_NO
	where pd.PROMOTION_DETAIL_NO+cm.customerTypeCode not in (Select PROGRAM_NO+MASTER_CODE from PROGRAM_MASTER_DATA)
	group by pd.PROMOTION_DETAIL_NO,cm.customerTypeCode

end	
---
drop table #SaleOnline_PromotionProgram,#SaleOnline_PromotionProgramDetail
	select 'OK'[Done] 
END 


TRY
BEGIN CATCH
     SELECT
    ERROR_NUMBER() AS ErrorNumber
    ,ERROR_SEVERITY() AS ErrorSeverity
    ,ERROR_STATE() AS ErrorState
    ,ERROR_PROCEDURE() AS ErrorProcedure
    ,ERROR_LINE() AS ErrorLine
    ,ERROR_MESSAGE() AS ErrorMessage;
END CATCH
/*delete SaleOnline_PromotionCustAttr
delete SaleOnline_PromotionCustAttrDetail
delete SaleOnline_PromotionShopMap
delete SaleOnline_PromotionProgram
delete SaleOnline_PromotionProgramDetail*/

end
 ---- SyncPromotion '2014/01/03 23:59:59'
