@echo off
SETLOCAL
SET NAMESPACE=*,Wsdot.Traffic
SET EXCLUDE=http://schemas.datacontract.org/2004/07/RoadwayLocation
PATH %PATH%;%programfiles(x86)%\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools\
svcutil /tcv:Version35 /nologo /n:%NAMESPACE% /config:TrafficApi.config http://www.wsdot.wa.gov/Traffic/api/HighwayAlerts/HighwayAlerts.svc?wsdl
svcutil /tcv:Version35 /mergeConfig /nologo /n:%NAMESPACE% /excludeType:%EXCLUDE% /config:TrafficApi.config http://www.wsdot.wa.gov/Traffic/api/HighwayCameras/HighwayCameras.svc?wsdl
svcutil /tcv:Version35 /mergeConfig /nologo /n:%NAMESPACE% /excludeType:%EXCLUDE% /config:TrafficApi.config http://www.wsdot.wa.gov/Traffic/api/MountainPassConditions/MountainPassConditions.svc?wsdl
svcutil /tcv:Version35 /mergeConfig /nologo /n:%NAMESPACE% /excludeType:%EXCLUDE% /config:TrafficApi.config http://www.wsdot.wa.gov/Traffic/api/TrafficFlow/TrafficFlow.svc?wsdl
svcutil /tcv:Version35 /mergeConfig /nologo /n:%NAMESPACE% /excludeType:%EXCLUDE% /config:TrafficApi.config http://www.wsdot.wa.gov/Traffic/api/TravelTimes/TravelTimes.svc?wsdl

ENDLOCAL