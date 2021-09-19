# proyecto_final_csharp_nivel2
Proyecto final del curso de Maxiprograma de C# Nivel 2. Usando SQL Server y .NET Framework

## Modelo de dominio:
> Clases:

- Artículos
- Marcas
- Categorías

> Negocio:

- ArtículoConexión.
- MarcaConexión.
- CategoriasConexión

> Formularios:

- Formulario principal (frmPrincipal): *Contiene tres botones los cuales consultan a las tres tablas por separado.*

    - Form1: Contiene la tabla con los datos de Artículos. Además de 4 botones: Agregar, Eliminar, Modificar y Ver Detalle, además de un recuadro de texto para filtrar la busqueda.
        -FrmArticulo: Usado para agregar, modificar y/o ver el detalle del artículo.

    - frmCategorias: Contiene la tabla con los datos de Categorias. Con 3 botones: Agregar, Modificar y eliminar.

    - frmMarcas: Contiene la tabla con los datos de Marcas. Mismos 3 botones.

        - frmSecundario: Al compartir los mismos campos entre las dos tablas de Marcas y Categorias (Id y Descripcion) se decidió usar un mismo formulario tanto para agregar como para modificar los elementos. Para esto se usaron dos constructores, uno recibía como argumento un objeto Marca y el otro un objeto Categoria. Al interactuar con el botón Aceptar se chequean si corresponde a un objeto o a otro, además de usar un atributo "acción" para saber si el usuario interactuó sobre el botón modificar o agregar.
