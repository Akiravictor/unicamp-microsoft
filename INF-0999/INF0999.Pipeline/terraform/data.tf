data "azurerm_resource_group" "resource_group" {
	name = "inf0999-ResourceGroup"
}

data "azurerm_key_vault" "key_vault" {
	name = "inf0999-Vault"
	resource_group_name = data.azurerm_resource_group.resource_group.name
}

data "azurerm_key_vault_secret" "sql_server_login" {
	name = "sqlServerUserLogin"
	key_vault_id = data.azurerm_key_vault.key_vault.id
}

data "azurerm_key_vault_secret" "sql_server_password" {
	name = "sqlServerUserPassword"
	key_vault_id = data.azurerm_key_vault.key_vault.id
}
