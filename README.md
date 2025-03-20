IMPORTANTE:
La aplicación no crea archivos de etiquetas, solamente los modifica, la creación del Id de etiqueta y de sus idiomas debe hacerse desde Visual Studio con el Wizard correspondiente. Si un idioma es añadido posteriormente desde Visual Studio también podrá ser accedido desde este formulario.
La aplicación debe iniciarse Como Administrador para que permita editar los archivos de idioma.

 ![image](https://github.com/user-attachments/assets/381523cb-cc06-418b-8208-f6368dcd205f)


1.	Botón para cargar los archivos de idiomas del modelo (5) y archivo de etiquetas (6) seleccionados.
2.	Botón que se utiliza para guardar los cambios de los archivos de idioma activos.
3.	Botón que abre el dialogo para configurar el directorio de modelos para la aplicación
4.	Botón con información sobre la aplicación.
5.	Control para seleccionar el modelo sobre el que se trabajará solo serán seleccionables los modelos marcados como es personalizable.
6.	Control para seleccionar el LabelID sobre el que se trabajará.
7.	Etiqueta para mostrar la información del archivo activo.
8.	Barra de búsqueda de etiquetas
9.	Grilla donde se cargarán los id de etiquetas y las descripciones para los idiomas disponibles.

Configurar el directorio de modelos
Es necesario configurar la ruta donde se encuentran las carpetas de los paquetes de la aplicación. Es la ruta donde se encuentra la carpeta PackagesLocalDirectory
Se debe hacer clic en el botón MODEL STORE SETTINGS, se accede al formulario donde se ingresa la ruta de configuración:

![image](https://github.com/user-attachments/assets/ce1d2802-bfe7-4c0a-9220-767f8cb9876a) 


Una vez seleccionado el modelo y el id de etiquetas y al hacer clic en el botón LOAD LANGUAGE FILE, En el grid aparecerán el Id de etiqueta y el contenido en cada una, generando una columna por cada idioma que se haya agregado al id de etiqueta. Además se mostrará la información del modelo y id de etiquetas activo.

![image](https://github.com/user-attachments/assets/938af687-ea5a-480a-aecd-6e327619f8f8)


La aplicación permite copiar el id de etiqueta en el mismo formato en el que lo hace Visual Studio. Al hacer clic derecho sobre la celda que se desea copiar. Al pegarla se pega con el formato, para el ejemplo: @APCEAMVarios:LblTaxGroupVisibility

![image](https://github.com/user-attachments/assets/076bbba0-10c1-4c11-8e74-244f3d681f5b)
 
KNOWN ISSUE: No se ha podido solventar un error en ciertas ocasiones al acceder a esta opción, sobre todo cuando se hace sobre la última fila, es conveniente darle Continuar para no perder algo que se esté haciendo.

![image](https://github.com/user-attachments/assets/b03cf97d-61cd-4b9c-99a4-7ea655a6f710)

KNOWN ISSUE: La opción de Copiar LabelId se basa en la posición del mouse respecto a la grilla, pero en ocasiones si el doble clic se hace muy en el borde o fuera del contenido de la celda puede copiar textos no deseados, el id anterior, posterior o incluso el texto del primer idioma, por lo que se recomienda que pueda asegurar de estar en el centro de la celda y además que al momento de pegar donde sea requerido se verifique que es el resultado esperado.

La aplicación permite editar directamente en el grid, cuando esto sucede, la celda editada se vuelve de color rojo y se marca la columna que ha sufrido alguna modificación.

![image](https://github.com/user-attachments/assets/63b3e138-d0aa-467c-ba4d-05a71f7d3442)

 
Al hacer clic en SAVE CHANGES se modificarán únicamente los archivos de idioma modificados, en este caso para el ejemplo es-MX, solicitando confirmación de la acción y notificando cuáles archivos fueron modificados.


![image](https://github.com/user-attachments/assets/64f93a36-7734-4e95-90b8-f8ee8d0a0aea)

![image](https://github.com/user-attachments/assets/c016a35c-0f1b-41c6-9b67-e345324671da)


 
El archivo se recarga automáticamente y la celda ya no aparece como modificada.
 
![image](https://github.com/user-attachments/assets/4a775de9-72fe-4a37-b5de-f5d6ce44503e)




Es posible añadir más ids de etiquetas pudiendo editar el contenido de los idiomas disponibles simultáneamente.

![image](https://github.com/user-attachments/assets/d8850133-1871-4614-9346-92eccaea8a64)

 
Una vez guardado se actualiza y se notifican la modificación de los archivos de idiomas correspondientes.
 

![image](https://github.com/user-attachments/assets/8b5d9ab0-3da9-4d13-8114-5a23510d54cb)
![image](https://github.com/user-attachments/assets/8406ee79-1e95-4a91-a1d2-d132210318e4)
![image](https://github.com/user-attachments/assets/956a1a62-c1ed-4707-860a-170dadf26345)




Es posible editar una sola columna de un idioma y poder copiar el contenido diferencia con el objetivo de igualar los idiomas

![image](https://github.com/user-attachments/assets/a7bebc03-8f32-4f1b-a3d8-15d7d8ce1ebb)


La opción Copy Column, copia toda la columna origen.
Para pegar lo copiado hay que ir a la columna destino, hacer doble clic sobre cualquier celda de la columna, hay dos opciones, Paste column que sustituye toda la columna destino y Paste only missing labels que copiará el contenido solo en las celdas vacías correspondientes con el índice de fila.
Ejemplo de Paste column

![image](https://github.com/user-attachments/assets/fb884210-f1cf-4ab3-9593-01c54bb84dc8)


Ejemplo de Paste Only Missing labels

![image](https://github.com/user-attachments/assets/ee35dde1-672e-47e3-b02a-0c1224d04ef8)


Esto permite que en archivos de etiquetas legacy poder corregir los archivos que no contienen valores para ciertas etiquetas en determinado idioma.

Puede filtrar para búsqueda de etiquetas incluso si hay modificaciones, manteniendo el indicador para las etiquetas ya modificadas.


![image](https://github.com/user-attachments/assets/04616bed-2b50-4efd-aa5e-83d80b19e27a)

![image](https://github.com/user-attachments/assets/3116e57a-2202-4ab7-9507-b59e1c4caac1)



Si intentan cargar otro archivo sin haber guardado el que están trabajando actualmente, se mostrará un mensaje de confirmación para evitar perder trabajo sin guardar.

![image](https://github.com/user-attachments/assets/fd425fbd-8399-488a-8f9f-ec03b65e4510)





