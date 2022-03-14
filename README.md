# Avance 1 Scripting 

Entrega del Primer Avance para la materia de Scripting realizada por:

- Juan Sebastían Mandón
- Juan Esteban Ciceri
- Nicolás Villa Vargas

Con la versión de Unity 2020.3.27f1 LTS

_Dificultades durante el proceso:_

Las complicaciones empezarón en el momento en el que le hicimos Fork a nuestro repo de taller para no interferir con el proceso de los otros compañeros que no están viendo Scripting. Esto dio como resultado las primeras dos dificultades: 

- Problemas de Compilación y demora en la importación del proyecto (se nos iban más de 10 min cada que importabamos a local el repo)
<img width="554" alt="ErrorCompilacion" src="https://user-images.githubusercontent.com/83988504/158104050-3b17bc14-2a1c-4e36-8c84-24f530e39780.png">
![DemoraImportando](https://user-images.githubusercontent.com/83988504/158106274-f9fb4103-fffc-4f8c-a980-d2b1d24c8c8e.png)

- La cuenta de Cicerí estaba subiendo los archivos a velocidad tortuga (sopechamos que puede estar relacionado a un probelma de los servidores a los que está asociada la cuenta...) 
- Cada Vez que Nico abría el proyecto en unity se le creaban más de 300 mil arvhicvos nuevos para subir al siguiente comit sin ni siquiera hacer algún cambio
<img width="314" alt="ArvhivosDeMas" src="https://user-images.githubusercontent.com/83988504/158105277-5abde9b7-0d6a-4f13-abf0-d837278359cb.png">

Empezanos a editar el gitIgnore y el propió proyecto en sí, importando y re importando el repo en nuestros pc´s, pero esto nos llevó a nuestra dificultad más grande:

  - Excedimos la capacidad de subir archivos de la cuenta de Mandón (quíen era el que tenía el repo forkeado original.)
![ErrorLTS](https://user-images.githubusercontent.com/83988504/158104417-54443b78-2473-4502-908c-1e77f8ae6a6f.png)
![CapatidadLTS-Mandon](https://user-images.githubusercontent.com/83988504/158104496-a3081178-ba37-4e2a-90cc-1ddd3c8d0ada.png)

  -Y como si fuera poco se nos corrompió como 6 veces (sino es que más) en todo el proceso, el proyecto nos llegaba con ajustes incompletos o con prefabs mal linqueados (Estabamos tan estresados que de esto no tomamos screens)

Así que decidimos intentar crear otro repo e ir subiendo entre todos comits de menos de 100mb (Subimos los archivos a un drive y cada uno descargó una parte para subirla

- No funconó, seguíamos llegando al tope antes de completar el contenido completo del repo.
![LimiteArchivos](https://user-images.githubusercontent.com/83988504/158104702-c75aabd7-fb0d-4536-af52-cb7a1481ce77.png)

Así que luego de evaluar nuestras opciones tuvimos que recurrir a crear una nueva cuenta, con el correo institucional (a ver si clasificabamos a acceder a una cuenta pro gratuita) y volvimos a empezar de nuevo 
![NuevaCuenta](https://user-images.githubusercontent.com/83988504/158105493-0b566818-272b-4113-ab6f-678d017452c4.png)

Desde aquí las cosas comezaron a mejorar gracias a que las dificultades disminuyeron...
- Aún así no faltarón los errores al empezar a hacer merch y de nuevo volvían adesaparecer algunos prefabs
![MerchErrors](https://user-images.githubusercontent.com/83988504/158105820-ecd473b1-b958-4733-932a-e60f41e20e47.png)

Y finalmente el resto de dificultades estuvieron en la curva de aprendizaje de las pruebas unitarias dentro de Unity.
- Pero en esencia lo unico que nos sigué dando sin funcionar fuerón las pruebas que teníamos pensadas para el movimiento porque el proyecto original usamos el nuevo input System de Unity y no encontramos una manera sencilla de simular los imputs del jugador, por ende nos dedicamos a testear las otras funcionalidades básicas del juego.
