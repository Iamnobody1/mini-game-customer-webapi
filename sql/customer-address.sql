--Province
SELECT "Id", "Name"
FROM public."Province"
where "EnabledFlag" = true
;

--District
SELECT "Id","Name"
FROM public."District"
where "EnabledFlag" = true and "ProvinceId" = 10
;

--SubDistrict
SELECT "Id", "Name"
FROM public."SubDistrict"
where "EnabledFlag" = true and "DistrictId" = 10
;

--PostalCode
SELECT "Id", "PostCode"
FROM public."PostalCode"
where "EnabledFlag" = true and "DistrictId" = 10
;

--Country
SELECT "Id", "Name",
FROM public."Country"
where "EnabledFlag" = true
;
alter table "Address" add constraint "Address_PostalCodeId_fkey" foreign key ("PostalCodeId") references public."PostalCode"("Id")