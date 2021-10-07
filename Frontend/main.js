window.onload = () => {
  var formulario = document.getElementById('F')
  formulario.addEventListener('submit', e => {
    e.preventDefault()
    console.log("Me diste un click")

    var datos = new FormData(formulario)
    console.log(datos.get(username))
    console.log(datos.get(password))
  })

  fetch('https://localhost:44366/api/users',{
    method: 'POST',
    body: datos
  })
    .then(res => res.json())
    .then(data => {
      console.log(data)
    })
}




