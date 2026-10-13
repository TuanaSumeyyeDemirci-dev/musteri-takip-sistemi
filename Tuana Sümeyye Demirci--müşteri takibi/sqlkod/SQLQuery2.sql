SELECT 
    COUNT(*) AS MusteriSayisi,
    MIN(mno) AS EnKucukNo,
    MAX(mno) AS EnBuyukNo
FROM [takip].[dbo].[musteri];
