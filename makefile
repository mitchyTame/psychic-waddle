PROJECT_NAME ?= SolarCoffee
ORG_NAME ?= SolarCoffee
REPO ?= SolarCoffee

.PHONY: migrations db

migrations:
	cd ./solarcoffee-data && dotnet ef --startup-project ../solarcoffee-web migrations add $(mname) && cd ..

db:
	cd ./solarcoffee-data && dotnet ef --startup-project ../solarcoffee-web database update && cd ..
