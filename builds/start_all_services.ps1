Start-Process Powershell.exe -Argumentlist "-NoExit -file start_api_gateway_service.ps1" -Verb runAs
Start-Process Powershell.exe -Argumentlist "-NoExit -file start_security_service.ps1" -Verb runAs
Start-Process Powershell.exe -Argumentlist "-NoExit -file start_audit_service.ps1" -Verb runAs
Start-Process Powershell.exe -Argumentlist "-NoExit -file start_customer_service.ps1" -Verb runAs
Start-Process Powershell.exe -Argumentlist "-NoExit -file start_order_service.ps1" -Verb runAs
Start-Process Powershell.exe -Argumentlist "-NoExit -file start_catalog_service.ps1" -Verb runAs
Start-Process Powershell.exe -Argumentlist "-NoExit -file start_payment_service.ps1" -Verb runAs
Start-Process Powershell.exe -Argumentlist "-NoExit -file start_checkout_service.ps1" -Verb runAs
Start-Process Powershell.exe -Argumentlist "-NoExit -file start_web.ps1" -Verb runAs