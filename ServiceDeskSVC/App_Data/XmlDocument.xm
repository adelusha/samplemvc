<?xml version="1.0"?>
<doc>
    <assembly>
        <name>ServiceDeskSVC</name>
    </assembly>
    <members>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketCategoryController.Get">
            <summary>
            Gets this instance.
            </summary>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketCategoryController.Post(ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets.HelpDesk_TicketCategory_vm)">
            <summary>
            Posts the specified value.
            </summary>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketCategoryController.Put(System.Int32,ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets.HelpDesk_TicketCategory_vm)">
            <summary>
            Puts the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketCategoryController.Delete(System.Int32)">
            <summary>
            Deletes the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.ApiDescriptionExtensions.GetFriendlyId(System.Web.Http.Description.ApiDescription)">
            <summary>
            Generates an URI-friendly ID for the <see cref="T:System.Web.Http.Description.ApiDescription"/>. E.g. "Get-Values-id_name" instead of "GetValues/{id}?name={name}"
            </summary>
            <param name="description">The <see cref="T:System.Web.Http.Description.ApiDescription"/>.</param>
            <returns>The ID as a string.</returns>
        </member>
        <member name="T:ServiceDeskSVC.Areas.HelpPage.HelpPageConfig">
            <summary>
            Use this class to customize the Help Page.
            For example you can set a custom <see cref="T:System.Web.Http.Description.IDocumentationProvider"/> to supply the documentation
            or you can provide the samples for the requests/responses.
            </summary>
        </member>
        <member name="T:ServiceDeskSVC.Areas.HelpPage.Controllers.HelpController">
            <summary>
            The controller that will handle requests for the help page.
            </summary>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.SetDocumentationProvider(System.Web.Http.HttpConfiguration,System.Web.Http.Description.IDocumentationProvider)">
            <summary>
            Sets the documentation provider for help page.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <param name="documentationProvider">The documentation provider.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.SetSampleObjects(System.Web.Http.HttpConfiguration,System.Collections.Generic.IDictionary{System.Type,System.Object})">
            <summary>
            Sets the objects that will be used by the formatters to produce sample requests/responses.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <param name="sampleObjects">The sample objects.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.SetSampleRequest(System.Web.Http.HttpConfiguration,System.Object,System.Net.Http.Headers.MediaTypeHeaderValue,System.String,System.String)">
            <summary>
            Sets the sample request directly for the specified media type and action.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <param name="sample">The sample request.</param>
            <param name="mediaType">The media type.</param>
            <param name="controllerName">Name of the controller.</param>
            <param name="actionName">Name of the action.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.SetSampleRequest(System.Web.Http.HttpConfiguration,System.Object,System.Net.Http.Headers.MediaTypeHeaderValue,System.String,System.String,System.String[])">
            <summary>
            Sets the sample request directly for the specified media type and action with parameters.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <param name="sample">The sample request.</param>
            <param name="mediaType">The media type.</param>
            <param name="controllerName">Name of the controller.</param>
            <param name="actionName">Name of the action.</param>
            <param name="parameterNames">The parameter names.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.SetSampleResponse(System.Web.Http.HttpConfiguration,System.Object,System.Net.Http.Headers.MediaTypeHeaderValue,System.String,System.String)">
            <summary>
            Sets the sample request directly for the specified media type of the action.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <param name="sample">The sample response.</param>
            <param name="mediaType">The media type.</param>
            <param name="controllerName">Name of the controller.</param>
            <param name="actionName">Name of the action.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.SetSampleResponse(System.Web.Http.HttpConfiguration,System.Object,System.Net.Http.Headers.MediaTypeHeaderValue,System.String,System.String,System.String[])">
            <summary>
            Sets the sample response directly for the specified media type of the action with specific parameters.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <param name="sample">The sample response.</param>
            <param name="mediaType">The media type.</param>
            <param name="controllerName">Name of the controller.</param>
            <param name="actionName">Name of the action.</param>
            <param name="parameterNames">The parameter names.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.SetSampleForMediaType(System.Web.Http.HttpConfiguration,System.Object,System.Net.Http.Headers.MediaTypeHeaderValue)">
            <summary>
            Sets the sample directly for all actions with the specified media type.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <param name="sample">The sample.</param>
            <param name="mediaType">The media type.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.SetSampleForType(System.Web.Http.HttpConfiguration,System.Object,System.Net.Http.Headers.MediaTypeHeaderValue,System.Type)">
            <summary>
            Sets the sample directly for all actions with the specified type and media type.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <param name="sample">The sample.</param>
            <param name="mediaType">The media type.</param>
            <param name="type">The parameter type or return type of an action.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.SetActualRequestType(System.Web.Http.HttpConfiguration,System.Type,System.String,System.String)">
            <summary>
            Specifies the actual type of <see cref="T:System.Net.Http.ObjectContent`1"/> passed to the <see cref="T:System.Net.Http.HttpRequestMessage"/> in an action.
            The help page will use this information to produce more accurate request samples.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <param name="type">The type.</param>
            <param name="controllerName">Name of the controller.</param>
            <param name="actionName">Name of the action.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.SetActualRequestType(System.Web.Http.HttpConfiguration,System.Type,System.String,System.String,System.String[])">
            <summary>
            Specifies the actual type of <see cref="T:System.Net.Http.ObjectContent`1"/> passed to the <see cref="T:System.Net.Http.HttpRequestMessage"/> in an action.
            The help page will use this information to produce more accurate request samples.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <param name="type">The type.</param>
            <param name="controllerName">Name of the controller.</param>
            <param name="actionName">Name of the action.</param>
            <param name="parameterNames">The parameter names.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.SetActualResponseType(System.Web.Http.HttpConfiguration,System.Type,System.String,System.String)">
            <summary>
            Specifies the actual type of <see cref="T:System.Net.Http.ObjectContent`1"/> returned as part of the <see cref="T:System.Net.Http.HttpRequestMessage"/> in an action.
            The help page will use this information to produce more accurate response samples.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <param name="type">The type.</param>
            <param name="controllerName">Name of the controller.</param>
            <param name="actionName">Name of the action.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.SetActualResponseType(System.Web.Http.HttpConfiguration,System.Type,System.String,System.String,System.String[])">
            <summary>
            Specifies the actual type of <see cref="T:System.Net.Http.ObjectContent`1"/> returned as part of the <see cref="T:System.Net.Http.HttpRequestMessage"/> in an action.
            The help page will use this information to produce more accurate response samples.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <param name="type">The type.</param>
            <param name="controllerName">Name of the controller.</param>
            <param name="actionName">Name of the action.</param>
            <param name="parameterNames">The parameter names.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.GetHelpPageSampleGenerator(System.Web.Http.HttpConfiguration)">
            <summary>
            Gets the help page sample generator.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <returns>The help page sample generator.</returns>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.SetHelpPageSampleGenerator(System.Web.Http.HttpConfiguration,ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator)">
            <summary>
            Sets the help page sample generator.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <param name="sampleGenerator">The help page sample generator.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.GetModelDescriptionGenerator(System.Web.Http.HttpConfiguration)">
            <summary>
            Gets the model description generator.
            </summary>
            <param name="config">The configuration.</param>
            <returns>The <see cref="T:ServiceDeskSVC.Areas.HelpPage.ModelDescriptions.ModelDescriptionGenerator"/></returns>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageConfigurationExtensions.GetHelpPageApiModel(System.Web.Http.HttpConfiguration,System.String)">
            <summary>
            Gets the model that represents an API displayed on the help page. The model is initialized on the first call and cached for subsequent calls.
            </summary>
            <param name="config">The <see cref="T:System.Web.Http.HttpConfiguration"/>.</param>
            <param name="apiDescriptionId">The <see cref="T:System.Web.Http.Description.ApiDescription"/> ID.</param>
            <returns>
            An <see cref="T:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel"/>
            </returns>
        </member>
        <member name="T:ServiceDeskSVC.Areas.HelpPage.ModelDescriptions.ModelDescription">
            <summary>
            Describes a type model.
            </summary>
        </member>
        <member name="T:ServiceDeskSVC.Areas.HelpPage.ModelDescriptions.ModelDescriptionGenerator">
            <summary>
            Generates model descriptions for given types.
            </summary>
        </member>
        <member name="T:ServiceDeskSVC.Areas.HelpPage.ModelDescriptions.ModelNameAttribute">
            <summary>
            Use this attribute to change the name of the <see cref="T:ServiceDeskSVC.Areas.HelpPage.ModelDescriptions.ModelDescription"/> generated for a type.
            </summary>
        </member>
        <member name="T:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel">
            <summary>
            The model that represents an API displayed on the help page.
            </summary>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel.#ctor">
            <summary>
            Initializes a new instance of the <see cref="T:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel"/> class.
            </summary>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel.ApiDescription">
            <summary>
            Gets or sets the <see cref="P:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel.ApiDescription"/> that describes the API.
            </summary>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel.UriParameters">
            <summary>
            Gets or sets the <see cref="T:ServiceDeskSVC.Areas.HelpPage.ModelDescriptions.ParameterDescription"/> collection that describes the URI parameters for the API.
            </summary>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel.RequestDocumentation">
            <summary>
            Gets or sets the documentation for the request.
            </summary>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel.RequestModelDescription">
            <summary>
            Gets or sets the <see cref="T:ServiceDeskSVC.Areas.HelpPage.ModelDescriptions.ModelDescription"/> that describes the request body.
            </summary>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel.RequestBodyParameters">
            <summary>
            Gets the request body parameter descriptions.
            </summary>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel.ResourceDescription">
            <summary>
            Gets or sets the <see cref="T:ServiceDeskSVC.Areas.HelpPage.ModelDescriptions.ModelDescription"/> that describes the resource.
            </summary>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel.ResourceProperties">
            <summary>
            Gets the resource property descriptions.
            </summary>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel.SampleRequests">
            <summary>
            Gets the sample requests associated with the API.
            </summary>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel.SampleResponses">
            <summary>
            Gets the sample responses associated with the API.
            </summary>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.Models.HelpPageApiModel.ErrorMessages">
            <summary>
            Gets the error messages associated with this model.
            </summary>
        </member>
        <member name="T:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator">
            <summary>
            This class will generate the samples for the help page.
            </summary>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.#ctor">
            <summary>
            Initializes a new instance of the <see cref="T:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator"/> class.
            </summary>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.GetSampleRequests(System.Web.Http.Description.ApiDescription)">
            <summary>
            Gets the request body samples for a given <see cref="T:System.Web.Http.Description.ApiDescription"/>.
            </summary>
            <param name="api">The <see cref="T:System.Web.Http.Description.ApiDescription"/>.</param>
            <returns>The samples keyed by media type.</returns>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.GetSampleResponses(System.Web.Http.Description.ApiDescription)">
            <summary>
            Gets the response body samples for a given <see cref="T:System.Web.Http.Description.ApiDescription"/>.
            </summary>
            <param name="api">The <see cref="T:System.Web.Http.Description.ApiDescription"/>.</param>
            <returns>The samples keyed by media type.</returns>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.GetSample(System.Web.Http.Description.ApiDescription,ServiceDeskSVC.Areas.HelpPage.SampleDirection)">
            <summary>
            Gets the request or response body samples.
            </summary>
            <param name="api">The <see cref="T:System.Web.Http.Description.ApiDescription"/>.</param>
            <param name="sampleDirection">The value indicating whether the sample is for a request or for a response.</param>
            <returns>The samples keyed by media type.</returns>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.GetActionSample(System.String,System.String,System.Collections.Generic.IEnumerable{System.String},System.Type,System.Net.Http.Formatting.MediaTypeFormatter,System.Net.Http.Headers.MediaTypeHeaderValue,ServiceDeskSVC.Areas.HelpPage.SampleDirection)">
            <summary>
            Search for samples that are provided directly through <see cref="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.ActionSamples"/>.
            </summary>
            <param name="controllerName">Name of the controller.</param>
            <param name="actionName">Name of the action.</param>
            <param name="parameterNames">The parameter names.</param>
            <param name="type">The CLR type.</param>
            <param name="formatter">The formatter.</param>
            <param name="mediaType">The media type.</param>
            <param name="sampleDirection">The value indicating whether the sample is for a request or for a response.</param>
            <returns>The sample that matches the parameters.</returns>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.GetSampleObject(System.Type)">
            <summary>
            Gets the sample object that will be serialized by the formatters. 
            First, it will look at the <see cref="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.SampleObjects"/>. If no sample object is found, it will try to create
            one using <see cref="M:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.DefaultSampleObjectFactory(ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator,System.Type)"/> (which wraps an <see cref="T:ServiceDeskSVC.Areas.HelpPage.ObjectGenerator"/>) and other
            factories in <see cref="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.SampleObjectFactories"/>.
            </summary>
            <param name="type">The type.</param>
            <returns>The sample object.</returns>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.ResolveHttpRequestMessageType(System.Web.Http.Description.ApiDescription)">
            <summary>
            Resolves the actual type of <see cref="T:System.Net.Http.ObjectContent`1"/> passed to the <see cref="T:System.Net.Http.HttpRequestMessage"/> in an action.
            </summary>
            <param name="api">The <see cref="T:System.Web.Http.Description.ApiDescription"/>.</param>
            <returns>The type.</returns>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.ResolveType(System.Web.Http.Description.ApiDescription,System.String,System.String,System.Collections.Generic.IEnumerable{System.String},ServiceDeskSVC.Areas.HelpPage.SampleDirection,System.Collections.ObjectModel.Collection{System.Net.Http.Formatting.MediaTypeFormatter}@)">
            <summary>
            Resolves the type of the action parameter or return value when <see cref="T:System.Net.Http.HttpRequestMessage"/> or <see cref="T:System.Net.Http.HttpResponseMessage"/> is used.
            </summary>
            <param name="api">The <see cref="T:System.Web.Http.Description.ApiDescription"/>.</param>
            <param name="controllerName">Name of the controller.</param>
            <param name="actionName">Name of the action.</param>
            <param name="parameterNames">The parameter names.</param>
            <param name="sampleDirection">The value indicating whether the sample is for a request or a response.</param>
            <param name="formatters">The formatters.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.WriteSampleObjectUsingFormatter(System.Net.Http.Formatting.MediaTypeFormatter,System.Object,System.Type,System.Net.Http.Headers.MediaTypeHeaderValue)">
            <summary>
            Writes the sample object using formatter.
            </summary>
            <param name="formatter">The formatter.</param>
            <param name="value">The value.</param>
            <param name="type">The type.</param>
            <param name="mediaType">Type of the media.</param>
            <returns></returns>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.ActualHttpMessageTypes">
            <summary>
            Gets CLR types that are used as the content of <see cref="T:System.Net.Http.HttpRequestMessage"/> or <see cref="T:System.Net.Http.HttpResponseMessage"/>.
            </summary>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.ActionSamples">
            <summary>
            Gets the objects that are used directly as samples for certain actions.
            </summary>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.SampleObjects">
            <summary>
            Gets the objects that are serialized as samples by the supported formatters.
            </summary>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleGenerator.SampleObjectFactories">
            <summary>
            Gets factories for the objects that the supported formatters will serialize as samples. Processed in order,
            stopping when the factory successfully returns a non-<see langref="null"/> object.
            </summary>
            <remarks>
            Collection includes just <see cref="M:ServiceDeskSVC.Areas.HelpPage.ObjectGenerator.GenerateObject(System.Type)"/> initially. Use
            <code>SampleObjectFactories.Insert(0, func)</code> to provide an override and
            <code>SampleObjectFactories.Add(func)</code> to provide a fallback.</remarks>
        </member>
        <member name="T:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey">
            <summary>
            This is used to identify the place where the sample should be applied.
            </summary>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey.#ctor(System.Net.Http.Headers.MediaTypeHeaderValue)">
            <summary>
            Creates a new <see cref="T:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey"/> based on media type.
            </summary>
            <param name="mediaType">The media type.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey.#ctor(System.Net.Http.Headers.MediaTypeHeaderValue,System.Type)">
            <summary>
            Creates a new <see cref="T:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey"/> based on media type and CLR type.
            </summary>
            <param name="mediaType">The media type.</param>
            <param name="type">The CLR type.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey.#ctor(ServiceDeskSVC.Areas.HelpPage.SampleDirection,System.String,System.String,System.Collections.Generic.IEnumerable{System.String})">
            <summary>
            Creates a new <see cref="T:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey"/> based on <see cref="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey.SampleDirection"/>, controller name, action name and parameter names.
            </summary>
            <param name="sampleDirection">The <see cref="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey.SampleDirection"/>.</param>
            <param name="controllerName">Name of the controller.</param>
            <param name="actionName">Name of the action.</param>
            <param name="parameterNames">The parameter names.</param>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey.#ctor(System.Net.Http.Headers.MediaTypeHeaderValue,ServiceDeskSVC.Areas.HelpPage.SampleDirection,System.String,System.String,System.Collections.Generic.IEnumerable{System.String})">
            <summary>
            Creates a new <see cref="T:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey"/> based on media type, <see cref="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey.SampleDirection"/>, controller name, action name and parameter names.
            </summary>
            <param name="mediaType">The media type.</param>
            <param name="sampleDirection">The <see cref="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey.SampleDirection"/>.</param>
            <param name="controllerName">Name of the controller.</param>
            <param name="actionName">Name of the action.</param>
            <param name="parameterNames">The parameter names.</param>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey.ControllerName">
            <summary>
            Gets the name of the controller.
            </summary>
            <value>
            The name of the controller.
            </value>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey.ActionName">
            <summary>
            Gets the name of the action.
            </summary>
            <value>
            The name of the action.
            </value>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey.MediaType">
            <summary>
            Gets the media type.
            </summary>
            <value>
            The media type.
            </value>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey.ParameterNames">
            <summary>
            Gets the parameter names.
            </summary>
        </member>
        <member name="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey.SampleDirection">
            <summary>
            Gets the <see cref="P:ServiceDeskSVC.Areas.HelpPage.HelpPageSampleKey.SampleDirection"/>.
            </summary>
        </member>
        <member name="T:ServiceDeskSVC.Areas.HelpPage.ImageSample">
            <summary>
            This represents an image sample on the help page. There's a display template named ImageSample associated with this class.
            </summary>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.ImageSample.#ctor(System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:ServiceDeskSVC.Areas.HelpPage.ImageSample"/> class.
            </summary>
            <param name="src">The URL of an image.</param>
        </member>
        <member name="T:ServiceDeskSVC.Areas.HelpPage.InvalidSample">
            <summary>
            This represents an invalid sample on the help page. There's a display template named InvalidSample associated with this class.
            </summary>
        </member>
        <member name="T:ServiceDeskSVC.Areas.HelpPage.ObjectGenerator">
            <summary>
            This class will create an object of a given type and populate it with sample data.
            </summary>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.ObjectGenerator.GenerateObject(System.Type)">
            <summary>
            Generates an object for a given type. The type needs to be public, have a public default constructor and settable public properties/fields. Currently it supports the following types:
            Simple types: <see cref="T:System.Int32"/>, <see cref="T:System.String"/>, <see cref="T:System.Enum"/>, <see cref="T:System.DateTime"/>, <see cref="T:System.Uri"/>, etc.
            Complex types: POCO types.
            Nullables: <see cref="T:System.Nullable`1"/>.
            Arrays: arrays of simple types or complex types.
            Key value pairs: <see cref="T:System.Collections.Generic.KeyValuePair`2"/>
            Tuples: <see cref="T:System.Tuple`1"/>, <see cref="T:System.Tuple`2"/>, etc
            Dictionaries: <see cref="T:System.Collections.Generic.IDictionary`2"/> or anything deriving from <see cref="T:System.Collections.Generic.IDictionary`2"/>.
            Collections: <see cref="T:System.Collections.Generic.IList`1"/>, <see cref="T:System.Collections.Generic.IEnumerable`1"/>, <see cref="T:System.Collections.Generic.ICollection`1"/>, <see cref="T:System.Collections.IList"/>, <see cref="T:System.Collections.IEnumerable"/>, <see cref="T:System.Collections.ICollection"/> or anything deriving from <see cref="T:System.Collections.Generic.ICollection`1"/> or <see cref="T:System.Collections.IList"/>.
            Queryables: <see cref="T:System.Linq.IQueryable"/>, <see cref="T:System.Linq.IQueryable`1"/>.
            </summary>
            <param name="type">The type.</param>
            <returns>An object of the given type.</returns>
        </member>
        <member name="T:ServiceDeskSVC.Areas.HelpPage.SampleDirection">
            <summary>
            Indicates whether the sample is used for request or response
            </summary>
        </member>
        <member name="T:ServiceDeskSVC.Areas.HelpPage.TextSample">
            <summary>
            This represents a preformatted text sample on the help page. There's a display template named TextSample associated with this class.
            </summary>
        </member>
        <member name="T:ServiceDeskSVC.Areas.HelpPage.XmlDocumentationProvider">
            <summary>
            A custom <see cref="T:System.Web.Http.Description.IDocumentationProvider"/> that reads the API documentation from an XML documentation file.
            </summary>
        </member>
        <member name="M:ServiceDeskSVC.Areas.HelpPage.XmlDocumentationProvider.#ctor(System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:ServiceDeskSVC.Areas.HelpPage.XmlDocumentationProvider"/> class.
            </summary>
            <param name="documentPath">The physical path to XML document.</param>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketDocumentController.Get(System.Int32)">
            <summary>
            Gets the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketDocumentController.GetAll(System.Int32)">
            <summary>
            Gets all.
            </summary>
            <param name="id">The identifier.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketDocumentController.Post(ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets.HelpDesk_TicketDocuments_vm)">
            <summary>
            Posts the specified value.
            </summary>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketDocumentController.Delete(System.Int32)">
            <summary>
            Deletes the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketCommentController.Get(System.Int32)">
            <summary>
            Gets the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketCommentController.Post(System.Int32,ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets.HelpDesk_TicketComments_vm)">
            <summary>
            Posts the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketCommentController.Put(System.Int32,ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets.HelpDesk_TicketComments_vm)">
            <summary>
            Puts the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketCommentController.Delete(System.Int32)">
            <summary>
            Deletes the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <returns></returns>
        </member>
        <member name="T:ServiceDeskSVC.Controllers.API.TicketStatusController">
            <summary>
            
            </summary>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketStatusController.Get">
            <summary>
            Gets this instance.
            </summary>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketStatusController.Post(ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets.HelpDesk_TicketStatus_vm)">
            <summary>
            Posts the specified value.
            </summary>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketStatusController.Put(System.Int32,ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets.HelpDesk_TicketStatus_vm)">
            <summary>
            Puts the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketStatusController.Delete(System.Int32)">
            <summary>
            Deletes the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketController.Get">
            <summary>
            Gets this instance.
            </summary>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketController.Get(System.Int32)">
            <summary>
            Gets the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketController.GetByUser(System.String)">
            <summary>
            Gets the by user.
            </summary>
            <param name="userName">Name of the user.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketController.GetByDepartment(System.Int32)">
            <summary>
            Gets the by department.
            </summary>
            <param name="departmentID">The department identifier.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketController.Post(ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets.HelpDesk_Tickets_vm)">
            <summary>
            Posts the specified value.
            </summary>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketController.Put(System.Int32,ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets.HelpDesk_Tickets_vm)">
            <summary>
            Puts the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketTypeController.Get">
            <summary>
            Gets this instance.
            </summary>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketTypeController.Post(ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets.HelpDesk_TicketType_vm)">
            <summary>
            Posts the specified value.
            </summary>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketTypeController.Put(System.Int32,ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tickets.HelpDesk_TicketType_vm)">
            <summary>
            Puts the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TicketTypeController.Delete(System.Int32)">
            <summary>
            Deletes the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TasksController.Get">
            <summary>
            Gets the Help Desk tasks
            </summary>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TasksController.Get(System.Int32)">
            <summary>
            Gets the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TasksController.GetTasksByTickets(System.Int32)">
            <summary>
            Gets the tasks by tickets.
            </summary>
            <param name="TicketId">The ticket identifier.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TasksController.Post(ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tasks.HelpDesk_Tasks_vm)">
            <summary>
            Posts the specified value.
            </summary>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TasksController.Put(System.Int32,ServiceDeskSVC.Domain.Entities.ViewModels.HelpDesk.Tasks.HelpDesk_Tasks_vm)">
            <summary>
            Puts the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:ServiceDeskSVC.Controllers.API.TasksController.Delete(System.Int32)">
            <summary>
            Deletes the specified identifier.
            </summary>
            <param name="id">The identifier.</param>
            <returns></returns>
        </member>
    </members>
</doc>
