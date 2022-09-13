;#DropDB XafDisableEnableFunctionalityEasyTest

#Application XafDisableEnableFunctionalityWin
#Application XafDisableEnableFunctionalityBlazor

*FillForm
 User Name = Admin
*Action Log In

#IfDef XafDisableEnableFunctionalityWin

*Action About...
 
*Action OK

#EndIf

#IfDef XafDisableEnableFunctionalityBlazor
*Action Navigation(My Details)
#EndIf
