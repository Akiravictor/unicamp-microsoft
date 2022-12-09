# Providers necessários para executar o script do Terraform
terraform {
    required_providers {
        azurerm = {
            source = "hashicorp/azurerm"
            version = "3.33.0"
        }
    }
}
 
# Configuração do provider AzureRM
provider "azurerm" {
  subscription_id = "4fde75b1-7c34-4801-88f1-45944b4e4929"
  client_id = "b228868c-f923-4356-8dbf-28d150bed674"
  client_secret = "u8x8Q~RpjGCxuqTNFzxV5naSPbDPSL7fjjki1bzC"
  tenant_id = "179b5913-afc3-448e-9350-455b204c0296"
  features {
   
  }
}
 
# Criação de um Resource Group no Azure Cloud
resource "azurerm_resource_group" "azure-devops" {
  name = "Inf0997-ResourceGroup"
  location = "Brazil South"
}
 
# Criação de um servidor para o Banco de Dados SQL Server
resource "azurerm_mssql_server" "azure-sql-server" {
  name = "inf0997-sqlserver"
  resource_group_name = azurerm_resource_group.azure-devops.name
  location = azurerm_resource_group.azure-devops.location
  version = "12.0"
  administrator_login = "inf0997Admin"
  administrator_login_password = "A1k9i9r1aAdmin!"
}
 
# Configuração do Banco de Dados SQL Server
resource "azurerm_mssql_database" "azure-database" {
  name = "inf0997-db"
  server_id = azurerm_mssql_server.azure-sql-server.id
  collation = "SQL_Latin1_General_CP1_CS_AS"
  max_size_gb = 2
  sku_name = "Basic"
}
 
# Adição de regras de Firewall do Banco de Dados
resource "azurerm_mssql_firewall_rule" "azure-db-firewall" {
  name             = "inf0997-firewall"
  server_id        = azurerm_mssql_server.azure-sql-server.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "255.255.255.255"
}
 
 
 
# Adição de um Service Plan para o Windows Server
resource "azurerm_service_plan" "azure-service-plan" {
  name                = "windows-server"
  resource_group_name = azurerm_resource_group.azure-devops.name
  location            = azurerm_resource_group.azure-devops.location
  os_type             = "Windows"
  sku_name            = "B1"
}
 
# Criação de um Azure Web App Windows para hospedar um Web App
resource "azurerm_windows_web_app" "azure-webapp-windows" {
  name                = "inf0997-sample"
  resource_group_name = azurerm_resource_group.azure-devops.name
  location            = azurerm_service_plan.azure-service-plan.location
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
