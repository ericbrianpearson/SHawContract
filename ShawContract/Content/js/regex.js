(function () {
    if ($ !== undefined) {
  
      // regex for international characters
      $.__nameRegex = /^[\.\-,'A-Za-z\u00C0-\u1FFF\u2800-\uFFFDÆÐƎƏƐƔĲŊŒẞÞǷȜæðǝəɛɣĳŋœĸſßþƿȝĄƁÇĐƊĘĦĮƘŁØƠŞȘŢȚŦŲƯY̨Ƴąɓçđɗęħįƙłøơşșţțŧųưy̨ƴÁÀÂÄǍĂĀÃÅǺĄÆǼǢƁĆĊĈČÇĎḌĐƊÐÉÈĖÊËĚĔĒĘẸƎƏƐĠĜǦĞĢƔáàâäǎăāãåǻąæǽǣɓćċĉčçďḍđɗðéèėêëěĕēęẹǝəɛġĝǧğģɣĤḤĦIÍÌİÎÏǏĬĪĨĮỊĲĴĶƘĹĻŁĽĿʼNŃN̈ŇÑŅŊÓÒÔÖǑŎŌÕŐỌØǾƠŒĥḥħıíìiîïǐĭīĩįịĳĵķƙĸĺļłľŀŉńn̈ňñņŋóòôöǒŏōõőọøǿơœŔŘŖŚŜŠŞȘṢẞŤŢṬŦÞÚÙÛÜǓŬŪŨŰŮŲỤƯẂẀŴẄǷÝỲŶŸȲỸƳŹŻŽẒŕřŗſśŝšşșṣßťţṭŧþúùûüǔŭūũűůųụưẃẁŵẅƿýỳŷÿȳỹƴźżžẓ\s]+$/g;
  
  
      // US phone numbers
      $.__phoneRegex = /^(1[\s\-\.]?)?((\([2-9][0-9]{2}\))|[2-9][0-9]{2})[\s\-\.]?[\0-9]{3}[\s\-\.]?[0-9]{4}$/g;
  
  
  
      /**
       * Adding a new method for regex validation to the jquery library
       */
      $.validator.addMethod('regex', function (value, element, param) {
        return this.optional(element) ||
          value.match(typeof param == 'string' ? new RegExp(param) : param);
      },
        'Please enter a value in the correct format.');
    }
  })();