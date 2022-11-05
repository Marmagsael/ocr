$(document).ready(function() {
  // Variables -----------------------------------------------
  var allMenuWrapper = $('.lmd-hdr');
  var allMenuText  = $('.lmd-hdr').children('.lmd-hdr-text');
  var allMenuIcons = $('.lmd-hdr').children('.lmd-hdr-icon1');

  var arrowLeft   = $('.lm-hdr').children('.lm-hdr-icon:first'); 
  var arrowRight  = $('.lm-hdr').children('.lm-hdr-icon:last'); 
  var userName    = $('.lm-hdr-text');
  var lmenuText   = $('.lmd-hdr-text');
  var lmenuToggle = $('.lmd-hdr-icon2'); //up and down arrow
  var subMenu     = $('.lm-child');
  var upArrow     = $(".lmd-hdr-icon2").children("span:first-of-type");
  var dwnArrow    = $(".lmd-hdr-icon2").children("span:last-of-type");


  $.fn._01ToggleNavDropDown = function() {   
    $('.nav-dd-user-img').click( function(){
      $('.nav-dd-dtls').toggle();
    });
  };
 
  $.fn._02ToggleLeftMenu = function() { 
    arrowRight.hide();

    $('.lm-hdr-icon').click( function(){
        $('#ocrLeft').toggleClass('lm-collapse');

        $.fn.defaultMenuTextAndIconStyle();

        if( $('#ocrLeft').hasClass('lm-collapse')){
          userName.hide();
          lmenuText.hide();
          lmenuToggle.hide();
          subMenu.hide();
          upArrow.hide();
          dwnArrow.show();

          arrowLeft.hide();
          arrowRight.show();
          
        } else {
          userName.show();
          lmenuText.show();
          lmenuToggle.show();
          arrowLeft.show();
          arrowRight.hide();
        }
      });
  };

  $.fn._03ExpandLeftMenuAndSubmenu = function() {   
    $('.lmd-hdr-icon1').click( function(){
      if( $('#ocrLeft').hasClass('lm-collapse')){
        $('#ocrLeft').removeClass('lm-collapse');
        arrowRight.hide();
        arrowLeft.show();

        userName.show();
        lmenuText.show();
        lmenuToggle.show();
        
        let mUp  = $(this).parent().children(".lmd-hdr-icon2").children("span:first");
        let mDwn  = $(this).parent().children(".lmd-hdr-icon2").children("span:last");

        let dwnIsVisible = $(mDwn).is(":visible"); 
        console.log('dwnIsVisible',dwnIsVisible);

        let ups  = $(".lmd-hdr-icon2").children("span:first-of-type"); 
        let dwns = $(".lmd-hdr-icon2").children("span:last-of-type");
        ups.hide(); 
        dwns.show(); 

        let submenus = $(".lm-child");
        submenus.hide();

        let submenu = $(this).parent().parent().children('div').eq(1);
        console.log('submenu',submenu)

        let menuWrapper = $(this).parent();
        let menuText = $(this).parent().children('.lmd-hdr-text');
        let menuIcon = $(this).parent().children('.lmd-hdr-icon1');

        $.fn.defaultMenuTextAndIconStyle();

        if(dwnIsVisible){
          mUp.show(); 
          mDwn.hide(); 
      
          submenu.show(); 
          menuWrapper.addClass('lmd-isActive-Menu')
          menuText.addClass('lmd-isActive-text') ;
          menuIcon.addClass('lmd-isActive-icon');
        } else {
          mUp.hide(); 
          mDwn.show(); 
    
          submenu.hide();  
          menuWrapper.removeClass('lmd-isActive-Menu')
          menuText.removeClass('lmd-isActive-text') ; 
          menuIcon.removeClass('lmd-isActive-icon'); 
        }
      };
    });
  };

  $.fn._04ToggleSubmenu = function() { 
    // --- Hide up button -----------------------------
    $(".lmd-hdr-icon2").children("span:first-of-type").hide();
    // --- Hide Menus -----------------------------
    $(".lm-child").hide();
    
    //  Toggle Menu
    $(".lmd-hdr").click(function() {
        
      var up  = $(this).children('.lmd-hdr-icon2').children("span:first"); 
      var dwn = $(this).children('.lmd-hdr-icon2').children("span:last");

      var dwnIsVisible = $(dwn).is(":visible"); 
      console.log('dwnIsVisible',dwnIsVisible)

      var ups  = $(".lmd-hdr-icon2").children("span:first-of-type"); 
      var dwns = $(".lmd-hdr-icon2").children("span:last-of-type");
      ups.hide(); 
      dwns.show(); 
      
      var menus = $(".lm-child"); 
      menus.hide(); 

      var menu = $(this).parent().children('div').eq(2);
      console.log('menu',menu)
      
      let menuWrapper = $(this);
      var menuText = $(this).children('.lmd-hdr-text');
      var menuIcon = $(this).children('.lmd-hdr-icon1');

      $.fn.defaultMenuTextAndIconStyle();
    
      if(dwnIsVisible) {
        // Click is down ---------------------
        up.show(); 
        dwn.hide(); 
    
        menu.show(); 
        console.log('>>>', menu)
        menuWrapper.addClass('lmd-isActive-Menu')

        menuText.addClass('lmd-isActive-text') ;
        menuIcon.addClass('lmd-isActive-icon');

      } else {
        // Click is up --------------------
        up.hide(); 
        dwn.show(); 

        menu.hide(); 
        menuWrapper.removeClass('lmd-isActive-Menu')
        menuText.removeClass('lmd-isActive-text') ; 
        menuIcon.removeClass('lmd-isActive-icon'); 
      }

    });
  };
   
  // -----------------------------------------------------------
  // --  General Functions -------------------------------------
  // -----------------------------------------------------------
  $.fn.defaultMenuTextAndIconStyle = function() { 
    allMenuWrapper.removeClass('lmd-isActive-Menu')
    allMenuText.removeClass('lmd-isActive-text');
    allMenuIcons.removeClass('lmd-isActive-icon');
  }

  $.fn._01ToggleNavDropDown();
  $.fn._02ToggleLeftMenu();
  $.fn._03ExpandLeftMenuAndSubmenu ();
  $.fn._04ToggleSubmenu();

    

 
})
  