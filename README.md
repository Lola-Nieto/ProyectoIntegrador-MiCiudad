https://www.twilio.com/en-us/blog/distribute-sessions-in-aspdotnet-core#:~:text=The%20HttpContext%20%2C%20as%20the%20name,a%20key%20of%20your%20choice. 



- Problema con la BD (no conecta, no la puede abrir)
- usuarioLogueado no lo encuentra (es un problema con los models o las carpetas?)
- Pasa por el js (porque tira el error con las contraseñas), pero no reconoce lo del dni ni usuario repetido --> puede ser en parte pq no abre la BD, pero el primer error no lo tira en la función donde llama eso, sino en agregar vecino
- Cambio en la navbar una vez logueado
- Botón de siguiente en olvide contraseña no hace nada (no si es que llama al js, este último no está haciendo lo que debería hacer)

Falta crear el usuario en el olvide contraseña 

No actualiza el DNI cuando llamo por segunda vez al js en la validación del Registro (si quiero modificar el dni)