﻿using Kentico.Kontent.Delivery;
using ShawContract.Providers.Kontent.Interfaces;

namespace ShawContract.Providers.Kontent.KontentHandler
{
    public class KontentDeliveryClient : IKontentDeliveryClient
    {
        public IDeliveryClient DeliveryClient { get; }

        private IKontentConfiguration KontentConfiguration { get; }

        public KontentDeliveryClient(IKontentConfiguration kontentConfiguration)
        {
            KontentConfiguration = kontentConfiguration;
            DeliveryClient = CreateDeliveryClient();
        }

        private IDeliveryClient CreateDeliveryClient()
        {
            return DeliveryClientBuilder
                .WithOptions(builder => builder
                .WithProjectId(KontentConfiguration.ProjectId)
                .UseProductionApi(KontentConfiguration.Key)
                .Build())
              .Build();
        }
    }
}