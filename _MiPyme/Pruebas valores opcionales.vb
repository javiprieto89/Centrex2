   If c.esMiPyME Then
                    fe.F1DetalleFchVtoPago = _fechaAFIP

                    fe.F1DetalleOpcionalItemCantidad = 1
                    'Primer  dato opcional a informar------------------------

                    fe.f1IndiceItem = 0
                    fe.F1DetalleOpcionalId = 2101      'CBU del Emisor------
                    fe.F1DetalleOpcionalValor = c.CBU_emisor

                    ' Segundo dato opcional a informar------------------------
                    fe.F1DetalleOpcionalItemCantidad = fe.F1DetalleOpcionalItemCantidad + 1
                    fe.f1IndiceItem = 1
                    fe.F1DetalleOpcionalId = 27
                    fe.F1DetalleOpcionalValor = "SCA"  'ADC lo puse en un parámetro por si hay que cambiarlo por empresa o futuros cambios

                    fe.F1DetalleOpcionalItemCantidad = fe.F1DetalleOpcionalItemCantidad + 1
                    'Tercer dato opcional a informar------------------------
                    fe.f1IndiceItem = 2
                    fe.F1DetalleOpcionalId = 2102      'ALIAS del Emisor------
                    fe.F1DetalleOpcionalValor = c.alias_CBU_emisor

                    ' fe.f1IndiceItem = 3
                    'fe.F1DetalleIvaItemCantidad = 1
                Else