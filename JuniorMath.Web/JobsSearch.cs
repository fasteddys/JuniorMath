﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;
using System.Configuration;
using JuniorMath.ApplicationCore.Enums;
using JuniorMath.ApplicationCore.Extensions;
using JuniorMath.ApplicationCore.DTOs.SearchIndex;
using JuniorMath.Infrastructure.Configuration.SiteSettings;
using Microsoft.Extensions.Options;

namespace JuniorMath.Web
{
    public class JobsSearch
    {
        private static SearchServiceClient _searchClient;
        private  SiteSettingsOptions _siteSettingsOptions { get; }

        public static string errorMessage;

        public JobsSearch(SiteSettingsOptions siteSettingsOptions)
        {
            _siteSettingsOptions = siteSettingsOptions;
            _searchClient = new SearchServiceClient(_siteSettingsOptions.AzureSearchServiceName, new SearchCredentials(_siteSettingsOptions.AzureSearchApiKey));
        }

        private ISearchIndexClient GetIndexClient(IndexNameType indexNameType)
        {
            var indexName = indexNameType.GetDescription();
            var indexClient = _searchClient.Indexes.GetClient(indexName);
            return indexClient;
        }

        public DocumentSearchResult<Document> Search(IndexNameType indexNameType, string searchText, string businessTitleFacet, string postingTypeFacet, string salaryRangeFacet,
            string sortType, double lat, double lon, int currentPage, int maxDistance, string maxDistanceLat, string maxDistanceLon)
        {
            try
            {
                SearchParameters sp = new SearchParameters()
                {
                    SearchMode = SearchMode.Any,
                    Top = 10,
                    Skip = currentPage - 1,
                    SearchFields = SearchIndexFields.GetSearchFields(indexNameType),
                    // Limit results
                    Select = SearchIndexFields.GetSelectFields(indexNameType),
                    //new List<String>() {"Id", "FirstName", "LastName", "Title", "Gender",
                    //    "Age", "Phone", "Email"},
                    // Add count
                    IncludeTotalResultCount = true,
                    // Add search highlights
                    HighlightFields = SearchIndexFields.GetHighlightFields(indexNameType),
                    //new List<String>() { "LastName" },
                    HighlightPreTag = "<b>",
                    HighlightPostTag = "</b>",
                    // Add facets
                   // Facets = new List<String>() { "business_title", "posting_type", "level", "salary_range_from,interval:50000" },
                };
                // Define the sort type
                //if (sortType == "featured")
                //{
                //    sp.ScoringProfile = "jobsScoringFeatured";      // Use a scoring profile
                //    sp.ScoringParameters = new List<ScoringParameter>();
                //    sp.ScoringParameters.Add(new ScoringParameter("featuredParam", new[] { "featured" }));
                //    sp.ScoringParameters.Add(new ScoringParameter("mapCenterParam", GeographyPoint.Create(lon, lat)));
                //}
                //else if (sortType == "salaryDesc")
                //    sp.OrderBy = new List<String>() { "salary_range_from desc" };
                //else if (sortType == "salaryIncr")
                //    sp.OrderBy = new List<String>() { "salary_range_from" };
                //else if (sortType == "mostRecent")
                //    sp.OrderBy = new List<String>() { "posting_date desc" };


                // Add filtering
                //string filter = null;
                //if (businessTitleFacet != "")
                //    filter = "business_title eq '" + businessTitleFacet + "'";
                //if (postingTypeFacet != "")
                //{
                //    if (filter != null)
                //        filter += " and ";
                //    filter += "posting_type eq '" + postingTypeFacet + "'";

                //}
                //if (salaryRangeFacet != "")
                //{
                //    if (filter != null)
                //        filter += " and ";
                //    filter += "salary_range_from ge " + salaryRangeFacet + " and salary_range_from lt " + (Convert.ToInt32(salaryRangeFacet) + 50000).ToString();
                //}

                //if (maxDistance > 0)
                //{
                //    if (filter != null)
                //        filter += " and ";
                //    filter += "geo.distance(geo_location, geography'POINT(" + maxDistanceLon + " " + maxDistanceLat + ")') le " + maxDistance.ToString();
                //}

                //sp.Filter = filter;

                var indexClient = GetIndexClient(indexNameType);
                return indexClient.Documents.Search(searchText, sp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error querying index: {0}\r\n", ex.Message.ToString());
            }
            return null;
        }

        //public DocumentSearchResult<Document> SearchZip(string zipCode)
        //{
        //    // Execute search based on query string
        //    try
        //    {
        //        SearchParameters sp = new SearchParameters()
        //        {
        //            SearchMode = SearchMode.All,
        //            Top = 1,
        //        };
        //        return _indexZipClient.Documents.Search(zipCode, sp);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error querying index: {0}\r\n", ex.Message.ToString());
        //    }
        //    return null;
        //}
        public AutocompleteResult AutoComplete(IndexNameType indexNameType, string term)
        {
            //Call autocomplete API and return results
            AutocompleteParameters ap = new AutocompleteParameters()
            {
                AutocompleteMode = AutocompleteMode.OneTermWithContext,
                UseFuzzyMatching = false,
                Top = 5
            };

            var indexClient = GetIndexClient(indexNameType);

            var autocompleteResult = indexClient.Documents.Autocomplete(term, "sg", ap);

            return autocompleteResult;
            //// Conver the Suggest results to a list that can be displayed in the client.
            //List<string> autocomplete = autocompleteResult.Results.Select(x => x.Text).ToList();
            //return new JsonResult(autocomplete);
            //return new JsonResult(new
            //{
            //    JsonRequestBehavior = 0,
            //    Data = autocomplete
            //});
        }

        public DocumentSuggestResult<Document> Suggest(IndexNameType indexNameType, bool highlights, bool fuzzy, string searchText)
        {
            try
            {
                SuggestParameters sp = new SuggestParameters()
                {
                    UseFuzzyMatching = fuzzy,
                    Top = 5
                };

                if (highlights)
                {
                    sp.HighlightPreTag = "<b>";
                    sp.HighlightPostTag = "</b>";
                }

                var indexClient = GetIndexClient(indexNameType);
               // var suggestResult = indexClient.Documents.Suggest(searchText, "sg", sp);


                return indexClient.Documents.Suggest(searchText, "sg", sp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error querying index: {0}\r\n", ex.Message.ToString());
            }
            return null;
        }

        public Document LookUp(IndexNameType indexNameType, string id)
        {
            try
            {
                var indexClient = GetIndexClient(indexNameType);
                return indexClient.Documents.Get(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error querying index: {0}\r\n", ex.Message.ToString());
            }
            return null;
        }
    }
}
