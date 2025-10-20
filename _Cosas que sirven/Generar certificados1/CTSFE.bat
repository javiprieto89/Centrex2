@Echo Off
If (%1)==()  Goto Msg
If %1==CP    Goto Cp
If %1==P12   Goto GenP12
If %1==PFX   Goto GenPFX

:Msg
Cls
Echo -----------------------------------------------------
Echo ComputronSystems
Echo El Archivo debe llamarse isd.cer si es un P12
Echo Los parametros son: P12 para generar archivo P12
Echo y CP para generar un requerimiento (.csr) para AFIP
Echo -----------------------------------------------------
Pause
Goto Fin

:Cp
Cls
Echo -----------------------------------------------------
Echo ComputronSystems
Echo Generando Archivo de Clave Privada
Echo Usar Contraseña: cts
Echo -----------------------------------------------------
OpenSSL\bin\openssl genrsa -des3 -out cts.pem 2048
Pause


Echo -----------------------------------------------------
Echo ComputronSystems
Echo Generando Archivo de Request para AFIP
Echo Usar Contraseña: cts
Echo -----------------------------------------------------
OpenSSL\bin\openssl req -config confCert.txt -out cts.request.csr -verify -key cts.pem -sha1 -new -batch
Pause
Goto Fin

Cls
Echo -----------------------------------------------------
Echo ComputronSystems
Echo Generando Archivo Auto Firmado para Testing
Echo Usar Contraseña: cts
Echo -----------------------------------------------------
Rem Con esto genero yo un .Cer, cosa que en realidad hace AFIP
Rem OpenSSL\bin\openssl req -x509 -days 1095 -config confCert.txt -out ctsTest.cer -verify -key cts.pem -sha1 -new -batch
pause
Goto Fin

:GenP12
Cls
Echo -----------------------------------------------------
Echo ComputronSystems
Echo Generando Certificado p12 Auto Firmado
Echo Usar Contraseña: cts para certificado.
Echo -----------------------------------------------------
OpenSSL\bin\openssl pkcs12 -export -in cts.crt -inkey cts.pem -out cts.p12
pause
Goto Fin

:GenPFX
Cls
Echo -----------------------------------------------------
Echo ComputronSystems
Echo Generando Certificado p12 Auto Firmado
Echo Usar Contraseña: cts para certificado.
Echo -----------------------------------------------------
OpenSSL\bin\openssl pkcs12 -export -in cts.crt -inkey cts.pem -out cts.pfx
pause

:Fin