// ---------------------------------------------------------------------- 	  
// Integracion JQuery
// ----------------------------------------------------------------------	  



// Funcion que valida la entrada de porcentajes

jQuery.fn.ForceCurrencyPercent =
		  function () {
		      return this.each(function () {
		          $(this).keydown(function (e) {
		              var result = false;

		              var key = e.charCode || e.keyCode || 0;
		              var dataKey = String.fromCharCode(key);


		              if (key == 190 || key == 110) {
		                  var texto = $(this).val()
		                  //console.log(texto.indexOf("."));		            	  
		                  result = (texto.indexOf(".") == -1) ? true : false;

		                  console.log(result);

		                  return result;
		              }



		              // nuevo bloque de validaciones para obtener solo numeros

		              var checkString = "0123456789";

		              if (key == 8 || key == 9 || key == 46) {
		                  result = true;
		              } else if (((checkString).indexOf(dataKey) > -1)) {
		                  result = true;
		              }

		              // proceso especial para el teclado extendido
		              if (key == 96 || key == 97 || key == 98 || key == 99 || key == 100 || key == 101 || key == 102 || key == 103 || key == 104 || key == 105) {
		                  result = true;
		              }



		              return result;
		          })
		      })
		  };

// Validador permite solo valores numericos y backspace 

jQuery.fn.ForceNumericOnly =
		  function () {
		      return this.each(function () {
		          $(this).keydown(function (e) {
		              var result = false;

		              // nuevo bloque de validaciones para bloquear el shift y ewvitar especiales
		              if (e.shiftKey) {
		                  return result;
		              }

		              var key = e.charCode || e.keyCode || 0;

		              // nuevo bloque de validaciones para obtener solo numeros
		              var dataKey = String.fromCharCode(key);
		              var checkString = "0123456789";

		              if (key == 8 || key == 9 || key == 46) {
		                  result = true;
		              } else if (((checkString).indexOf(dataKey) > -1)) {
		                  result = true;
		              }
		              // proceso especial para el teclado extendido
		              if (key == 96 || key == 97 || key == 98 || key == 99 || key == 100 || key == 101 || key == 102 || key == 103 || key == 104 || key == 105) {
		                  result = true;
		              }

		              return result;
		          })
		      })
		  };



// Validador permite solo valores numericos y backspace 

jQuery.fn.ForceNumericOnly01 =
		  function () {
		      return this.each(function () {
		          $(this).keydown(function (e) {
		              var result = false;

		              // nuevo bloque de validaciones para bloquear el shift y ewvitar especiales
		              if (e.shiftKey) {
		                  return result;
		              }

		              var key = e.charCode || e.keyCode || 0;

		              // nuevo bloque de validaciones para obtener solo numeros
		              var dataKey = String.fromCharCode(key);
		              var checkString = "23456789";

		              if (key == 8 || key == 9 || key == 46) {
		                  result = true;
		              } else if (((checkString).indexOf(dataKey) > -1)) {
		                  result = true;
		              }
		              // proceso especial para el teclado extendido
		              if (key == 96 || key == 97 || key == 98 || key == 99 || key == 100 || key == 101 || key == 102 || key == 103 || key == 104 || key == 105) {
		                  result = true;
		              }

		              return result;
		          })
		      })
		  };




// Validador permite solo valores alfanumericos y backspace
jQuery.fn.ForceAlphaNumericOnly =
		  function () {
		      return this.each(function () {
		          $(this).keydown(function (e) {
		              if (e.shiftKey) {
		                  return false;
		              }
		              var key = e.charCode || e.keyCode || 0;
		              return (
		                  key == 8 ||
		                  key == 9 ||
		                  key == 32 ||
		                  key == 46 ||
		                  (key >= 37 && key <= 40) ||
		                  (key >= 48 && key <= 57) ||
		                  (key >= 65 && key <= 90) ||
		                  (key >= 96 && key <= 105)
		                  );
		          })
		      })
		  };

// Validador permite solo valores alfanumericos y parentesis
		  jQuery.fn.ForceAlphaNumericForTel =
		  function () {
		      return this.each(function () {
		          $(this).keydown(function (e) {
		              if (e.shiftKey) {
		                  return true;
		              }
		              var key = e.charCode || e.keyCode || 0;
		              return (key == 8 ||
		                  key == 9 ||
		                  key == 32 ||
		                  key == 46 ||
		                  (key >= 37 && key <= 41) ||
		                  (key >= 48 && key <= 57) ||
		                  (key >= 65 && key <= 90) ||
		                  (key >= 96 && key <= 105)
                          );
		          })
		      })
		  };

// Validador permite solo valores letras y backspace
jQuery.fn.ForceAlphaOnly =
		  		  function () {
		  		      return this.each(function () {
		  		          $(this).keydown(function (e) {
		  		              if (e.shiftKey) {
		  		                  //return false;   /// LEGS Se procesan las mayusculas
		  		              }
		  		              var key = e.charCode || e.keyCode || 0;
		  		              return (
		  		                  key == 8 ||
		  		                  key == 9 ||
		  		                  key == 32 ||
		  		                  key == 46 ||
                                  key == 164 ||
                                  key == 165 ||
                                  key == 192 ||     // Se incrmentan las "ñ"
		  		                  (key >= 37 && key <= 40) ||
		  		                  (key >= 65 && key <= 90) ||
		  		                  (key >= 96 && key <= 105)
		  		                  );
		  		          })
		  		      })
		  		  };

// Validador que permite solo valores de numeros y puntos  
jQuery.fn.ForceDoubleOnly =
		  		  function () {
		  		      return this.each(function () {
		  		          $(this).keydown(function (e) {
		  		              var result = false;

		  		              // nuevo bloque de validaciones para bloquear el shift y ewvitar especiales
		  		              if (e.shiftKey) {
		  		                  return result;
		  		              }

		  		              var key = e.charCode || e.keyCode || 0;

		  		              // nuevo bloque de validaciones para obtener solo numeros
		  		              var dataKey = String.fromCharCode(key);
		  		              var checkString = "0123456789";
		  		              if (key == 8 || key == 9 || key == 46 || key == 190 || key == 110) {
		  		                  result = true;
		  		              } else if (((checkString).indexOf(dataKey) > -1)) {
		  		                  result = true;
		  		              }

		  		              // proceso especial para el teclado extendido
		  		              if (key == 96 || key == 97 || key == 98 || key == 99 || key == 100 || key == 101 || key == 102 || key == 103 || key == 104 || key == 105) {
		  		                  result = true;
		  		              }

		  		              return result;
		  		          })
		  		      })
		  		  };
// Validador permite solo valores alfanumericos y backspace
jQuery.fn.ForceAlphaNumericPercentOnly =
		  		  function () {
		  		      return this.each(function () {
		  		          $(this).keydown(function (e) {
		  		              var result = false;

		  		              // nuevo bloque de validaciones para bloquear el shift y ewvitar especiales


		  		              var key = e.charCode || e.keyCode || 0;

		  		              // nuevo bloque de validaciones para obtener solo numeros
		  		              var dataKey = String.fromCharCode(key);
		  		              var checkString = "0123456789";
		  		              if (key == 8 || key == 9 || key == 46 || key == 190 || key == 37 || key == 47) {
		  		                  result = true;
		  		              } else if (((checkString).indexOf(dataKey) > -1)) {
		  		                  result = true;
		  		              }
		  		              else {
		  		                  result = false;
		  		              }
		  		              return result;
		  		          })
		  		      })
		  		  };