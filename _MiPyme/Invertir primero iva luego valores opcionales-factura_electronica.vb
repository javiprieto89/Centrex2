	  fe.F1DetalleFchVtoPago = _fechaAFIP

						fe.F1DetalleOpcionalItemCantidad = 1
						'Primer  dato opcional a informar------------------------

						fe.f1IndiceItem = 0

						fe.F1DetalleOpcionalId = 2101      'CBU del Emisor------

						fe.F1DetalleOpcionalValor = c.alias_CBU_emisor

                    fe.F1DetalleOpcionalItemCantidad = 1
                    'Si se usa 2101 en F1DetalleOpcionalId se debe informar CBU del emisor donde al momento de pagar la factura se abonará el saldo en esa CBU
                    'Actualmente se usa ese método, se deja la otra opción grisada
                    'fe.f1IndiceItem = 0
                    'fe.F1DetalleOpcionalId = "2101"
                    'fe.F1DetalleOpcionalValor = c.CBU_emisor
                    'Si desea informar el alias en vez del CBU del emisor, debe grisar las lineas anteriores y usar estas
                    fe.f1IndiceItem = 0
                    fe.F1DetalleOpcionalId = "2102"
                    fe.F1DetalleOpcionalValor = c.alias_CBU_emisor

                    fe.f1IndiceItem = 1
                    fe.F1DetalleOpcionalId = 27
                    fe.F1DetalleOpcionalValor = info_modoMiPyme(c.id_modoMiPyme).abreviatura

                    'Si es una nota de crédito y es un comprobante que ya fue anulado por el cliente se debe mandar una S, si todavía no fue anulado por el cliente, una N
                    If UCase(c.anula_MiPyME) = "S" Or UCase(c.anula_MiPyME) = "N" Then
                        fe.F1DetalleOpcionalItemCantidad = 1
                        fe.f1IndiceItem = 0
                        fe.F1DetalleOpcionalId = 22
                        fe.F1DetalleOpcionalValor = UCase(c.anula_MiPyME)
                    End If