# INFORMACIÓN GENERAL

Lo relacionado a la granja a su funcionamiento en general, y por cómo está distribuído son sacados del tutorial de "SilverlyBee": https://www.youtube.com/watch?v=gEnogKcRf-g&list=PLGTLEXyxopGwdv9ysisF2FlLg_TLceWAA, añadiendo también los plugins e informaciones de ChainSafe: https://docs.gaming.chainsafe.io/

En dicho tutorial se explica cómo funciona y cómo se arma la granja desde 0

## Cosas a tener en cuenta

1. Es importante tener en cuenta que el tiempo de crecimiento de las plantas es _ALEATORIO_ por lo cuál si se desea cambiar, es importante informarse bien sobre el tema.

2. Para mejor funcionamiento del proyecto, preferiblemente crear un nuevo repositorio en GIT a partir de una copia de este repositorio, y eliminar la carpeta .GitHub/workflows, para hacer una integración mucho más cómoda. (Ver tutorial de "The power ups - Learning": https://www.youtube.com/watch?v=u5LGtbsodpE)

# FUNCIONALIDADES DE EL PROYECTO

1. Conexión con la wallet y se muestran a sus diferentes partes (Balance y Address)

2. Riego, fertilización, deshierbado de las plantas, así como el comprado de semillas

3. Las plantas cambian de etapa en un intérvalo aletatorio de entre 0-10 segundos, por lo cuál es necesario

4) El proyecto actualmente funciona con CI/CD (Ver punto 2 de "Cosas a tener en cuenta" que e encuentra antes)

## Puntos importantes

1. El proyecto aún NO tiene conexión establecida con una base de datos (preferiblemente hacerlo con moralisWeb3)

2. El balance de las token BTF es muy desbalanceado se descuenta demasiado sin ganancia clara (Revisar los test). Almancenar esta información dentro de la base de datos de moralis.

3. La aplicación web no está funcionando correctamente, esto debido a que el proyecto la primera vez se ejecuta correctamente en web, pero al intentar iniciar sesión nuevamente salta un error de Web3 que por motivos de tiempo no se pudo solucionar. Por lo cuál únicamente está funcionando como aplicación de escritorio (únicamente para pruebas, pero se espera que para el lanzamiento sea web)

4. La integración de la base de datos debe hacerse en conjunto con el Marketplace y la página para evitar inconvenientes, y errores al tratar de combinar la información.

5. Hace falta la implementación de un inventario dentro del juego (Preferiblemente en el lanzamiento), dónde se vean las especies de café a cultivar (Versiones posteriores al lanzamiento), se vean las herramientas que tiene el jugador para las diferentes acciones.

6. Debido a lo explicado en el punto 5 es necesario que se haga lo explicado en el punto 4, para facilitar la compra de las herramientas, los granos de café, los NFT del jugador, etc.

7. Las plots o parcelas son fijas, es necesario buscar una solución para que sea ampliable la granja.

8. Hacen falta botones que sean capaces de hacer una acción en varias plantas a la vez, por ejemplo para regar las plantas, y no regar una por una, un botón que permita regar las que no están regadas a la vez, lo mismo para las otras acciones (Aquí el jugador tiene la libertad de decidir si hacerlo una por una, o varias a la vez, en cualquier momento).

9. Aún no hay NFTs implementados dentro del juego, por lo cuál es necesario crear un Contrato para las NFT, en Solidity preferiblemente (Si no tiene conocimiento sobre Solidity o Blockchain, Buscar en "CryptoZombie" o algún tutorial externo).

10. El contrato como la red sobre la cuál se está trabajando deben ser cambiadas sobre los scripts de WEB3, para evitar inconvenientes, y crear un contrato nuevo de La token principal sobre la testnet de Binance (Buscar en la documentación Oficial para conectar Metamask con la testnet).

## Créditos

Todo lo relacionado al desarrollo del proyecto hasta la fecha (15/12/2022), se agradece a los canales de Youtube donde se encuentra la información repectiva y relevante al proyecto, al igual que la implementación y trabajo sobre los desarrolladores: Miguel Angel Giraldo Castañeda, Sebastián David Rendón Soto y Karen Manuela Lara. Estos fueron los primeros desarrolladores sobre el juego de MetaCoffeeCoin que actualmente ya no participan en el proyecto.

Contacto y dudas sobre esta primera etapa de implementación del proyecto hecha hasta la fecha (15/12/2022) con Miguel Angel Giraldo Castañeda, WhatsApp: +57 3229272302.

# A futuro

1. Trabajar con un nuevo repositorio.

2. Mantener los créditos de los desarrolladores, además de añadir los nombres de los nuevos.

3. Las desiciones que se tomen a partir de la fecha (15/12/2022) para cambios sobre el proyecto, la implementación de éste y futuras decisiones se harán por el respectivo equipo de desarrollo que se encuentre activo en el momento.
