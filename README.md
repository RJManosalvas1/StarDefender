# 🚀 StarDefender
### Videojuego 2D estilo *space shooter*, desarrollado en Unity como proyecto integrador.

---

## 🎮 Descripción del Juego

**StarDefender** es un shooter espacial donde controlas una nave que avanza automáticamente mientras te desplazas horizontalmente para esquivar enemigos y destruirlos con tus disparos.

El objetivo principal es **sobrevivir**, eliminar enemigos y enfrentar al **Jefe Final** que aparece al alcanzar un número determinado de enemigos abatidos.

---

## 🕹️ Mecánicas Principales

- Movimiento de la nave en el eje **X** (izquierda/derecha).
- Avance automático hacia adelante.
- Disparo del jugador (proyectiles que destruyen enemigos).
- Enemigos que se generan dinámicamente frente a la nave.
- Sistema de vida del jugador.
- Contador de enemigos abatidos.
- Aparición de **Boss** al llegar al umbral de kills.
- Colisiones:
  - Bala ⟶ Enemigo
  - Enemigo / Boss ⟶ Jugador

---

## 👾 Enemigos y Jefe Final

### Enemigos Comunes
- Se instancian por medio de un **EnemySpawner**.
- Tienen vida configurable y otorgan puntos al morir.
- Aumentan el contador de enemigos abatidos.

### Jefe Final
- Se genera cuando el jugador alcanza cierta cantidad de kills (por ejemplo, 15).
- Se mueve horizontalmente en la parte superior de la pantalla.
- Puede hacer daño al jugador por contacto (y se puede extender para que dispare).
- Representa el reto final del nivel.

---

## 🎨 Estética y Animaciones

- Fondo espacial con desplazamiento para dar sensación de movimiento.
- Prefabs para la nave, enemigos, balas y boss.
- Animaciones o efectos (explosión, disparos, etc. según versión final).
- Interfaz con:
  - Contador de enemigos: `Enemigos: X / N`
  - Vida del jugador
  - (Opcional) Escudo, puntaje y mensajes de estado.

---

## 🔍 Colisiones y Detectores

- Uso de `Collider2D` y `Rigidbody2D` en jugador, enemigos y balas.
- Detección de impactos mediante `OnTriggerEnter2D` y/o `OnCollisionEnter2D`.
- Manejo de:
  - Daño al jugador.
  - Destrucción de enemigos.
  - Activación de eventos (como aparición del boss).

---

## 🗺️ Escenarios e Instanciación

- Sistema de **spawners** para generar enemigos dinámicamente.
- Posiciones aleatorias dentro de un rango por delante de la nave.
- Aparición de un jefe final mediante lógica en el `GameManager`.
- Posibilidad de escalar dificultad ajustando:
  - Velocidad de los enemigos.
  - Frecuencia de aparición.

---

## 🧩 Tecnologías Utilizadas

- **Unity** (versión usada durante el curso).
- **C#** para la programación de lógica de juego.
- **TextMeshPro** para la interfaz de usuario.
- **Git y GitHub** para control de versiones.
- **WebGL** (para la versión publicada en Itch.io, si aplica).

---

## 🖥️ Controles

```text
A / ← : Mover hacia la izquierda
D / → : Mover hacia la derecha
Espacio / clic izquierdo : Disparar
ESC (opcional) : Pausa / menú
