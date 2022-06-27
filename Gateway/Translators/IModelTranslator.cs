namespace DatingApp.FrontEnd.Gateway.Translators
{
    public interface IModelTranslator<TGateway, TModel>
    {
        TGateway GetGatewayModel(TModel model);
        TModel GetModel(TGateway model);
    }
}
