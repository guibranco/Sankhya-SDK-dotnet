using System;
using Sankhya.Enums;

namespace Sankhya.Helpers;

public sealed class EntityQueryOptions
{
    private TimeSpan _timeout;

    public int? MaxResults { get; set; }

    public bool? IncludeReferences { get; set; }

    public ReferenceLevel? MaxReferenceDepth { get; set; }

    public bool? IncludePresentationFields { get; set; }

    public bool? UseWildcardFields { get; set; }

    public TimeSpan Timeout
    {
        get
        {
            if (_timeout == TimeSpan.Zero)
            {
                _timeout = new(0, 30, 0);
            }

            return _timeout;
        }
        set => _timeout = value;
    }
}
