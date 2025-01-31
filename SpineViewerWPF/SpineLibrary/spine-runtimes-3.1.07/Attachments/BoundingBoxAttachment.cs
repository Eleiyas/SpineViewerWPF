/******************************************************************************
 * Spine Runtimes Software License
 * Version 2.3
 * 
 * Copyright (c) 2013-2015, Esoteric Software
 * All rights reserved.
 * 
 * You are granted a perpetual, non-exclusive, non-sublicensable and
 * non-transferable license to use, install, execute and perform the Spine
 * Runtimes Software (the "Software") and derivative works solely for personal
 * or internal use. Without the written permission of Esoteric Software (see
 * Section 2 of the Spine Software License Agreement), you may not (a) modify,
 * translate, adapt or otherwise create derivative works, improvements of the
 * Software or develop new applications using the Software or (b) remove,
 * delete, alter or obscure any trademarks or any copyright, trademark, patent
 * or other intellectual property or proprietary rights notices on or in the
 * Software, including any copy thereof. Redistributions in binary or source
 * form must include this license and terms.
 * 
 * THIS SOFTWARE IS PROVIDED BY ESOTERIC SOFTWARE "AS IS" AND ANY EXPRESS OR
 * IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
 * MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO
 * EVENT SHALL ESOTERIC SOFTWARE BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
 * PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS;
 * OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
 * OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *****************************************************************************/

namespace Spine3_1_07
{
    /// <summary>Attachment that has a polygon for bounds checking.</summary>
    public class BoundingBoxAttachment : Attachment
    {
        internal float[] vertices;

        public float[] Vertices { get { return vertices; } set { vertices = value; } }

        public BoundingBoxAttachment(string name)
            : base(name)
        {
        }

        /// <param name="worldVertices">Must have at least the same length as this attachment's vertices.</param>
        public void ComputeWorldVertices(Bone bone, float[] worldVertices)
        {
            float x = bone.skeleton.x + bone.worldX, y = bone.skeleton.y + bone.worldY;
            float m00 = bone.a;
            float m01 = bone.b;
            float m10 = bone.c;
            float m11 = bone.d;
            float[] vertices = this.vertices;
            for (int i = 0, n = vertices.Length; i < n; i += 2)
            {
                float px = vertices[i];
                float py = vertices[i + 1];
                worldVertices[i] = px * m00 + py * m01 + x;
                worldVertices[i + 1] = px * m10 + py * m11 + y;
            }
        }
    }
}
