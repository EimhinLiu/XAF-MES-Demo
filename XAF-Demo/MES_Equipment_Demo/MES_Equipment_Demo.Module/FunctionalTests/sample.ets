;#DropDB MES_Equipment_DemoEasyTest

#Application MES_Equipment_DemoWin
#Application MES_Equipment_DemoWeb
#IfDef MES_Equipment_DemoWin

*Action About...
 
*Action OK

#EndIf

#IfDef MES_Equipment_DemoWeb
!Action Navigation(My Details)
#EndIf
