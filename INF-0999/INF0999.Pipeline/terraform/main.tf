# Providers necessarios para executar o script do Terraform
terraform {
    required_providers {
        azurerm = {
            source = "hashicorp/azurerm"
            version = "3.33.0"
        }
    }
    backend "azurerm" {
      resource_group_name = "inf0999-ResourceGroup"
      storage_account_name = "inf0999storageaccount"
      container_name = "inf099tfstate"
      #access_key = "TiEWwtg339YQBoNHJklc9GKg/51wiOGRDC+6EXTWuS8caFs9AvJRBvhj6ZQraE+dAbOkJaJ+agaH+AStTKoGYw=="
      key = "terraform.tfstate"
    }
}

# Configuração do provider AzureRM
provider "azurerm" {
  client_id = var.client_id
  client_secret = var.client_secret
  subscription_id = var.subscription_id
  tenant_id = var.tenant_id
  features {
   
  }
}

# Criação de um servidor para o Banco de Dados SQL Server
resource "azurerm_mssql_server" "azure-sql-server" {
  name = "inf0999-sqlserver"
  resource_group_name = local.resource_group_name
  location = local.resource_group_location
  version = "12.0"
  administrator_login = local.sql_server_login
  administrator_login_password = local.sql_server_password
}
 
# Configuração do Banco de Dados SQL Server
resource "azurerm_mssql_database" "azure-database" {
  name = "inf0999-db"
  server_id = azurerm_mssql_server.azure-sql-server.id
  collation = "SQL_Latin1_General_CP1_CS_AS"
  max_size_gb = 2
  sku_name = "Basic"
}
 
# Adição de regras de Firewall do Banco de Dados
resource "azurerm_mssql_firewall_rule" "azure-db-firewall" {
  name             = "inf0999-firewall"
  server_id        = azurerm_mssql_server.azure-sql-server.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "255.255.255.255"
}

# Adição de um Service Plan para o Windows Server
resource "azurerm_service_plan" "azure-service-plan" {
  name                = "windows-server"
  resource_group_name = local.resource_group_name
  location            = local.resource_group_location
  os_type             = "Windows"
  sku_name            = "B1"
}
 
# Criação de um Azure Web App Windows para hospedar um Web App
resource "azurerm_windows_web_app" "azure-webapp-windows" {
  name                = "inf0999-OngConnection"
  resource_group_name = local.resource_group_name
  location            = local.resource_group_location
  service_plan_id     = azurerm_service_plan.azure-service-plan.id
 
  site_config {
    application_stack {
      current_stack = "dotnet"
      dotnet_version = "v6.0"
    }
  }
 
  identity {
    type = "SystemAssigned"
  }
 
}