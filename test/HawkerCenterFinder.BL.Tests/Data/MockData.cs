using HawkerCenterFinder.Model;
using HawkerCenterFinder.Model.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawkerCenterFinder.BL.Tests.Data
{
    public static class MockData
    {
        public static List<Hawker> mockHawkersData = new List<Hawker>
        {
            new Hawker
            {
                Id = 1,
                ImgUrl = "Https://abc.com/img.jpeg",
                Latitude="103.938732580554",
                Longitude="1.33198706861747",
                Name ="Mock 1 Hawker Center"
            },
            new Hawker
            {
                Id = 2,
                ImgUrl = "Https://bcd.com/img.jpeg",
                Latitude="103.818338919994",
                Longitude="1.28733076703987",
                Name ="Mock 2 Hawker Center"
            },
            new Hawker
            {
                Id = 3,
                ImgUrl = "Https://def.com/img.jpeg",
                Latitude="103.828994204342",
                Longitude="1.37238494002145",
                Name ="Mock 3 Hawker Center"
            },
            new Hawker
            {
                Id = 4,
                ImgUrl = "Https://ghi.com/img.jpeg",
                Latitude="103.866737484646",
                Longitude="1.3631571201113",
                Name ="Mock 4 Hawker Center"
            },
            new Hawker
            {
                Id = 5,
                ImgUrl = "Https://jkl.com/img.jpeg",
                Latitude="103.915761950557",
                Longitude="1.30577514781108",
                Name ="Mock 5 Hawker Center"
            },
        };

        public static List<HawkerCenterResponse> mockHawkerResponseData = new List<HawkerCenterResponse>
        {
            new HawkerCenterResponse
            {
                ImgUrl = "Https://abc.com/img.jpeg",
                Name ="Mock 1 Hawker Center"
            },
            new HawkerCenterResponse
            {
                ImgUrl = "Https://bcd.com/img.jpeg",
                Name ="Mock 2 Hawker Center"
            },
            new HawkerCenterResponse
            {
                ImgUrl = "Https://def.com/img.jpeg",
                Name ="Mock 3 Hawker Center"
            },
            new HawkerCenterResponse
            {
                ImgUrl = "Https://ghi.com/img.jpeg",
                Name ="Mock 4 Hawker Center"
            },
            new HawkerCenterResponse
            {
                ImgUrl = "Https://jkl.com/img.jpeg",
                Name ="Mock 5 Hawker Center"
            },
        };
    }
}
