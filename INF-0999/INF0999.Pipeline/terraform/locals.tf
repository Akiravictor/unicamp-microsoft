locals {
    sql_server_login = data.azurerm_key_vault_secret.sql_server_login.value
    sql_server_password = data.azurerm_key_vault_secret.sql_server_password.value
    resource_group_name = data.azurerm_resource_group.resource_group.name
    resource_group_location = data.azurerm_resource_group.resource_group.location
}