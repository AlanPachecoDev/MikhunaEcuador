/*----------------------------------------------Subida y carga de la imágen del perfil------------------------------------------------*/
const cloudinaryUrl = 'https://api.cloudinary.com/v1_1/dbxw3bxby/image/upload'; //link de acceso a cloudinary
const cloudinaryPreset = "skjte8mz"; //contraseña para acceso

const imgUploderPerfil = document.getElementById('imageUploaderPerfil');  //Elemento subida de imágen
const imgPreviewPerfil = document.getElementById('imgPreviewPerfil'); //Elemento que mostrará la imágen

imgUploderPerfil.addEventListener('change', async (event) => {  //evento cuando cambio de selección de imágen
    const fileImg = event.target.files[0];    //guarda el FILE de la img subida

    const formData = new FormData();    //crea un formulario de html
    formData.append('file', fileImg);   //añade elemento fileImg a 'file'
    formData.append('upload_preset', cloudinaryPreset); //añade la contraseña a 'upload_preset'
    console.log("Entra");
    const res = await axios.post(cloudinaryUrl, formData, {       //Establece conexión con cloudinary mediante axios.post y
        headers: {                                               // guarda la respueusta en "res"
            'Content-Type': 'multipart/form-data'                 //Envía la info guardada en "headers"

        }
    });  //axios.post permite establecer conexión con cloudinary, en la ur "cloudinaryUrl" y envia los datos del formulario "formData" que contiene el FILe (imágen) y la contraseña
    imgPreviewPerfil.src = res.data.secure_url;    //pone la imágen en el html
    //document.getElementById("imageDiv2").style.display = "none";

    document.getElementById("UrlImgPerfil").value = res.data.secure_url;

});