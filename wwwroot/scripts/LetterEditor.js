//TinyMCE(https://www.tiny.cloud/) is used to provide rich text editing functionality when producing the letter.

tinymce.init({
    selector: '#LetterContent ',
    noneditable_class: 'ModelField',
    plugins: "autoresize",


    //InsertModelFields = custom toolbar option that allows the user to insert placeholder text that will be replaced with data from model when letter is generated.
    toolbar: "undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | InsertModelFields",

    setup: function (editor) {
        //Returns a drop-down menu containing options to insert details related to the student and letter. This is not a full-implementation and is more proof-of-concept.
        //Refer to https://www.tiny.cloud/docs/demo/custom-toolbar-menu-button/
        editor.ui.registry.addMenuButton('InsertModelFields', {
            text: 'Insert fields',
            fetch: function (callback) {
                var items = [
                    {
                        type: 'nestedmenuitem',
                        text: 'Student',
                        getSubmenuItems: function () {
                            return [
                                {
                                    type: 'menuitem',
                                    text: 'First Name',
                                    onAction: function () {
                                        editor.insertContent('<span class="ModelField">{{Student First Name}}</span>');
                                    }
                                },
                                {
                                    type: 'menuitem',
                                    text: 'Last Name',
                                    onAction: function () {
                                        editor.insertContent('<span class="ModelField">{{Student Last Name}}</span>');
                                    }
                                },
                                {
                                    type: 'menuitem',
                                    text: 'Full Name',
                                    onAction: function () {
                                        editor.insertContent('<span class="ModelField">{{Student Full Name}}</span>');
                                    }
                                },

                                {
                                    type: 'menuitem',
                                    text: 'Guardian',
                                    onAction: function () {
                                        editor.insertContent('<span class="ModelField">{{Guardian}}</span>');
                                    }
                                },


                            ];
                        }
                    },
                    {
                        type: 'nestedmenuitem',
                        text: 'Letter',
                        getSubmenuItems: function () {
                            return [
                                {
                                    type: 'menuitem',
                                    text: 'Reference',
                                    onAction: function () {
                                        editor.insertContent('<span class="ModelField">{{Reference}}</span>');
                                    }
                                },
                                {
                                    type: 'menuitem',
                                    text: 'Payment Link',
                                    onAction: function () {
                                        editor.insertContent('<span class="ModelField">{{Payment Link}}</span>');
                                    }
                                },
                                {
                                    type: 'menuitem',
                                    text: 'Outstanding Balance',
                                    onAction: function () {
                                        editor.insertContent('<span class="ModelField">{{Outstanding Balance}}</span>');
                                    }
                                },

                            ];
                        }
                    },

                ];
                callback(items);
            }
        });

    },

    init_instance_callback: (function (inst) {
        $.ajax({
            type: 'GET',
            url: 'getLetterTemplate',
            dataType: 'html',
            data: {},
            success: function (data) {
                inst.setContent(data);
            },
            error: function (xhr, status, error) {
                inst.setContent(xhr.responseText);
            }

        });
        return false;
    })
});